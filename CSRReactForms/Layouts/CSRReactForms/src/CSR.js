import React from 'react'
import ReactDOM from 'react-dom'
import { ControlTab } from './controls/ControlTab.tsx';
import { ControlText } from './controls/ControlText.tsx';




Type.registerNamespace('CSR')
var CSR = CSR || {}
CSR.Templates = CSR.Templates || {};
CSR.Functions = CSR.Functions || {};
CSR.Variables = CSR.Variables || {}; 
CSR.Variables.Items = CSR.Variables.Items || [];
CSR.Variables.Fields = CSR.Variables.Fields || {};


CSR.NewOrEditControl = function(ctx) {
    
    var fieldInternalName = ctx.CurrentFieldSchema.Name
    var controlId = fieldInternalName + "_ReactControl"
    var _inputId = fieldInternalName + "_InputControl"
    var _value = ctx.CurrentFieldValue
    var _ErrorMessge;

    
    var validators = new SPClientForms.ClientValidation.ValidatorSet()
    if (ctx.CurrentFieldSchema.Required) { //проверка на Requeird
        validators.RegisterValidator(new SPClientForms.ClientValidation.RequiredValidator());
    }        
    ctx.FormContext.registerClientValidator(fieldInternalName, validators);      

    ctx.FormContext.registerFocusCallback(fieldInternalName, function() {
        $get(_inputId).focus();
    });

    ctx.FormContext.registerValidationErrorCallback(fieldInternalName, function(errorResult) {        
        _ErrorMessge = errorResult.errorMessage;
        ReactDOM.render(
            <ControlText value = {_value} id = {_inputId} error = {_ErrorMessge} />,
            document.getElementById(controlId)
        )
    });

    ctx.FormContext.registerInitCallback(fieldInternalName, function () {        
        ReactDOM.render(
            <ControlText value = {_value} id = {_inputId} error = {_ErrorMessge} />,
            document.getElementById(controlId)
        )
        $addHandler($get(_inputId), "change", function(e) {
            ctx.FormContext.updateControlValue(fieldInternalName, $get(_inputId).value);
        });
    });

    ctx.FormContext.registerGetValueCallback(fieldInternalName, function () { 
        return document.getElementById(_inputId).value; 
    }); 

    return '<div ="CustomControl"><div id="'+controlId+'"></div></div>'    

}

CSR.Functions.AddField = function(ctx) {
    var MSForm = document.getElementById('WebPartWPQ2').getElementsByClassName('ms-formtable')[0]     
    if (MSForm != undefined ) {
        var fieldInternalName = ctx.ListSchema.Field[0].Name  
        var ref = MSForm.querySelector('[id^="' + fieldInternalName + '_"]').parentNode.parentNode.parentNode        
        ref.style.display = 'none'  
        CSR.Variables.Fields[fieldInternalName] = ref  
    }
    return CSR
}


CSR.Functions.CreateTab = function(ctx) {
    var MSForm = document.getElementById('WebPartWPQ2').getElementsByClassName('ms-formtable')[0];      
    if (MSForm != undefined && MSForm.parentNode.querySelector('.TabComponent') == null ) { 
        var TabComponent = document.createElement('div')
        TabComponent.className = "TabComponent"
        MSForm.insertAdjacentElement('beforebegin', TabComponent)         
                     
        ReactDOM.render(
            <ControlTab />                
            ,TabComponent
        )   
    }    
    return CSR
}


export default CSR