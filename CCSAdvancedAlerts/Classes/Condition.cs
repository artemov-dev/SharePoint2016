﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;

namespace CCSAdvancedAlerts
{
    [Serializable]
    class Condition
    {
        public const string ValueCollectionSeperator = ";";

        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        private Operators comparisionOperator;
        public Operators ComparisionOperator
        {
            get { return comparisionOperator; }
            set { comparisionOperator = value; }
        }

        private string strValue;
        public string StrValue
        {
            get { return strValue; }
            set { strValue = value; }
        }

        private ConditionComparisionType comparisionType;
        public ConditionComparisionType ComparisionType
        {
            get { return comparisionType; }
            set { comparisionType = value; }
        }


        //private string whenToSend;
        //internal string WhenToSend
        //{
        //    get { return whenToSend; }
        //    set { whenToSend = value; }
        //}

        public Condition(string xNode)
        {
            if (!string.IsNullOrEmpty(xNode))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xNode);
                BuildConditionFromXML(xDoc.DocumentElement);
            }
        }

        public Condition(XmlNode xNode)
        {
            if (xNode != null)
                BuildConditionFromXML(xNode as XmlElement);
        }

        public Condition()
        {
        }

        private void BuildConditionFromXML(XmlElement xmlElement)
        {
            try
            {
                this.FieldName = xmlElement.GetAttribute("Field");
                this.comparisionOperator = (Operators)Enum.Parse(typeof(Operators), xmlElement.GetAttribute("Operator"));
                this.strValue = xmlElement.GetAttribute("Value");
                this.comparisionType = (ConditionComparisionType)Enum.Parse(typeof(ConditionComparisionType), xmlElement.GetAttribute("ComparisionType"));
            }
            catch { }
        }


        #region Condition Evaluation

        internal bool isValid(SPListItem item, AlertEventType eventType, SPItemEventProperties properties)
        {
            SPList list = item.ParentList;
            if (list == null)
                return false;
            SPField field = list.Fields.TryGetFieldByStaticName(this.fieldName);
            ConditionValueType valType = GetConditionValueType();

            if (field != null && valType != ConditionValueType.Invalid)
            {
                object fieldValue = item[this.fieldName];
                if (eventType == AlertEventType.ItemUpdated && properties !=null)
                {
                    if (this.comparisionType != ConditionComparisionType.Always)
                    {
                        //if (!properties.AfterProperties.ChangedProperties.Contains(this.fieldName))
                        if (Convert.ToString(item[this.fieldName])
                            .Equals(Convert.ToString(properties.AfterProperties[this.fieldName]), StringComparison.CurrentCultureIgnoreCase))
                        {
                            return false;
                        }
                        else
                        {
                            fieldValue = properties.AfterProperties[this.fieldName];
                        }
                    }
                }

                return MatchItemValueBasedOnOperatorAndValueType(fieldValue, field.FieldValueType, eventType,item.ParentList.ParentWeb);
            }

            return false;
        }

        public bool MatchItemValueBasedOnOperatorAndValueType(object fieldValue, Type fieldValueType, AlertEventType eventType, SPWeb web)
        {
            //SPWeb web = item.ParentList.ParentWeb;
            //string strComputedValue = GetConditionComputedValue(item);

            if (fieldValue != null && !string.IsNullOrEmpty(fieldValue.ToString()))
            {
                if (fieldValueType == (typeof(SPFieldUrlValue)))
                {
                    SPFieldUrlValue fieldUrlValue = new SPFieldUrlValue(fieldValue.ToString());
                    bool isDescMatched = CompareValuesBasedOnOperator(fieldUrlValue.Description, this.comparisionOperator, this.strValue);
                    bool isUrlMatched = CompareValuesBasedOnOperator(fieldUrlValue.Url, this.comparisionOperator, strValue);

                    return isDescMatched || isUrlMatched;
                }
                else if (fieldValueType == (typeof(SPFieldUserValue)))
                {
                    //SPFieldUserValue fieldUserValue = new SPFieldUserValue(SPContext.Current.Web, fieldValue.ToString());
                    SPFieldUserValue fieldUserValue = new SPFieldUserValue(web, fieldValue.ToString());

                    string userLoginName = fieldUserValue.User.LoginName;
                    string userDispalyName = fieldUserValue.User.Name;

                    bool isLoginMatched = CompareValuesBasedOnOperator(userLoginName, this.comparisionOperator, strValue);
                    bool isDisplayNameMatched = CompareValuesBasedOnOperator(userLoginName, this.comparisionOperator, strValue);

                    return isLoginMatched || isDisplayNameMatched;

                }
                else if (fieldValueType == (typeof(SPFieldUserValueCollection)))
                {
                    //SPFieldUserValueCollection fieldUserValueCollection = new SPFieldUserValueCollection(SPContext.Current.Web, fieldValue.ToString());
                    SPFieldUserValueCollection fieldUserValueCollection = new SPFieldUserValueCollection(web, fieldValue.ToString());
                    string userLoginNames = "";
                    string userDispalyNames = "";

                    foreach (SPFieldUserValue userValue in fieldUserValueCollection)
                    {
                        userLoginNames += userValue.LookupValue + ValueCollectionSeperator;

                        if (userValue.User != null)
                            userDispalyNames += userValue.User.Name + ValueCollectionSeperator;

                    }

                    userLoginNames = userLoginNames.TrimEnd(ValueCollectionSeperator.ToCharArray());
                    userDispalyNames = userDispalyNames.TrimEnd(ValueCollectionSeperator.ToCharArray());

                    bool isLoginMatched = CompareValuesBasedOnOperator(userLoginNames, this.comparisionOperator, strValue);
                    bool isDisplayNameMatched = CompareValuesBasedOnOperator(userLoginNames, this.comparisionOperator, strValue);

                    return isLoginMatched || isDisplayNameMatched;



                }
                else if (fieldValueType == (typeof(SPFieldLookupValue)))
                {
                    SPFieldLookupValue fieldLookupValue = new SPFieldLookupValue(fieldValue.ToString());

                    string strFieldValue = fieldLookupValue.LookupValue;
                    return CompareValuesBasedOnOperator(strFieldValue, this.comparisionOperator, strValue);
                }
                else if (fieldValueType == (typeof(SPFieldLookupValueCollection)))
                {
                    SPFieldLookupValueCollection fieldLookupValueCollection = new SPFieldLookupValueCollection(fieldValue.ToString());
                    string strFieldValue = "";

                    foreach (SPFieldLookupValue lookup in fieldLookupValueCollection)
                    {
                        strFieldValue += lookup.LookupValue + ValueCollectionSeperator;
                    }

                    strFieldValue = strFieldValue.TrimEnd(ValueCollectionSeperator.ToCharArray());
                    return CompareValuesBasedOnOperator(strFieldValue, this.comparisionOperator, strValue);
                }
                else if (fieldValueType == (typeof(DateTime)))
                {
                    DateTime sourceDT = DateTime.Parse(fieldValue.ToString());
                    DateTime targetDT = new DateTime();
                    if (DateTime.TryParse(strValue, out targetDT))
                    {
                        switch (this.comparisionOperator)
                        {

                            case Operators.Eq:
                                return sourceDT == targetDT;
                            case Operators.Neq:
                                return sourceDT != targetDT;
                            case Operators.Gt:
                                return sourceDT > targetDT;
                            case Operators.Geq:
                                return sourceDT >= targetDT;
                            case Operators.Lt:
                                return sourceDT < targetDT;
                            case Operators.Leq:
                                return sourceDT <= targetDT;
                            default:
                                return false;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
                else if (fieldValueType == (typeof(int)))
                {
                    int sourceInt = int.Parse(fieldValue.ToString());
                    int targetInt;
                    if (Int32.TryParse(strValue, out targetInt))
                    {
                        switch (this.comparisionOperator)
                        {

                            case Operators.Eq:
                                return sourceInt == targetInt;
                            case Operators.Neq:
                                return sourceInt != targetInt;
                            case Operators.Gt:
                                return sourceInt > targetInt;
                            case Operators.Geq:
                                return sourceInt >= targetInt;
                            case Operators.Lt:
                                return sourceInt < targetInt;
                            case Operators.Leq:
                                return sourceInt <= targetInt;
                            default:
                                return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (fieldValueType == (typeof(Boolean)))
                {
                    bool sourceBool = Boolean.Parse(fieldValue.ToString());
                    bool targetBool = false;

                    if (strValue.Equals("True", StringComparison.InvariantCultureIgnoreCase) || strValue.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
                    {
                        targetBool = true;
                    }
                    else if (strValue.Equals("False", StringComparison.InvariantCultureIgnoreCase) || strValue.Equals("No", StringComparison.InvariantCultureIgnoreCase))
                    {
                        targetBool = false;
                    }
                    else
                    {
                        return false;
                    }

                    switch (this.comparisionOperator)
                    {

                        case Operators.Eq:
                            return sourceBool == targetBool;
                        case Operators.Neq:
                            return sourceBool != targetBool;
                        case Operators.Contains:
                            return sourceBool == targetBool;
                        case Operators.NotContains:
                            return sourceBool != targetBool;
                        default:
                            return false;
                    }
                }
                else // default matching will be performed with string type
                {
                    string strFieldValue = fieldValue.ToString();
                    return CompareValuesBasedOnOperator(strFieldValue, this.comparisionOperator, strValue);
                }
            }
            else
            {
                return false;
            }

        }

        private static bool CompareValuesBasedOnOperator(string sourceValue, Operators op, string targetValue)
        {
            sourceValue = sourceValue.Trim();
            targetValue = targetValue.Trim();
            switch (op)
            {

                case Operators.Eq:
                    return sourceValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
                case Operators.Neq:
                    return !sourceValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
                case Operators.Contains:
                    return sourceValue.IndexOf(targetValue, StringComparison.InvariantCultureIgnoreCase) > -1;
                case Operators.NotContains:
                    return !(sourceValue.IndexOf(targetValue, StringComparison.InvariantCultureIgnoreCase) > -1);
                default:
                    return false;
            }
        }

        #endregion Condition Evaluation


        #region Computed Condition Values

        internal string GetConditionComputedValue(SPListItem item)
        {
            ConditionValueType valType = GetConditionValueType();
            string propVal = this.StrValue.Trim();

            switch (valType)
            {
                case ConditionValueType.StringLiteral:
                    return this.StrValue;

                case ConditionValueType.ItemPropertyValue:
                    {
                        string propName = propVal.Substring(1, propVal.Length - 2);
                        SPField field = item.ParentList.Fields.TryGetFieldByStaticName(propName);
                        if (field != null)
                        {
                            return Convert.ToString(item[propName]);
                        }
                    }
                    break;

                case ConditionValueType.FunctionOnPropertyValue:
                    {
                        int open = propVal.IndexOf('(');
                        int close = propVal.IndexOf(')');

                        string funcName = propVal.Substring(1, open - 1);
                        string propNameExp = propVal.Substring(open + 1, close - open - 1);
                        string propName = propNameExp.Substring(1, propNameExp.Length - 2);

                        SPField field = item.ParentList.Fields.TryGetFieldByStaticName(propName);
                        if (field != null)
                        {
                            switch (funcName)
                            {
                                case "strlen":
                                    {
                                        return Convert.ToString(Convert.ToString(item[propName]).Length);
                                    }
                            }
                        }
                    }
                    break;
            }

            throw new Exception("Invalid argument for computed condition value");
        }

        // TODO: write a regular expression for this
        // TODO: Add validations for valid property name and function name
        // Valid condition values are:
        // value
        // [propName]
        // $FuncName(value or [propName])
        internal ConditionValueType GetConditionValueType()
        {
            ConditionValueType ret = ConditionValueType.Invalid;

            String strVal = this.StrValue.Trim();
            if (!string.IsNullOrEmpty(strVal))
            {
                if (IsLiteralStringValue(strVal))
                    return ConditionValueType.StringLiteral;

                if (IsValidItemPropertyExpression(strVal))
                    return ConditionValueType.ItemPropertyValue;

                if (strVal[0] == '$')
                {
                    int startFunc = strVal.IndexOf('(', 2);
                    int endFunc = strVal.IndexOf(')', startFunc);

                    if (startFunc > 0 && endFunc > startFunc + 1)
                    {
                        string propExp = strVal.Substring(startFunc + 1, endFunc - startFunc - 1);

                        if (IsLiteralStringValue(propExp))
                        {
                            // Not supporting function values on literals as it is not useful
                            //return ConditionValueType.Function;
                            return ConditionValueType.Invalid;
                        }
                            
                        if(IsValidItemPropertyExpression(propExp))
                            return ConditionValueType.FunctionOnPropertyValue;
                    }
                }
            }

            return ret;
        }

        internal bool IsLiteralStringValue(string strVal)
        {
            if (strVal.IndexOfAny(new char[] { '$', '[', ']', '(', ')' }) < 0)
                return true;

            return false;
        }

        internal bool IsValidItemPropertyExpression(string strVal)
        {
            if (!string.IsNullOrEmpty(strVal) &&
                strVal.StartsWith("[") && strVal.EndsWith("]") &&
                strVal.IndexOfAny(new char[] { '$', '(', ')' }) < 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }

}
