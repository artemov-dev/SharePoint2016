﻿<%@ Page language="C#" MasterPageFile="~masterurl/default.master" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
    <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />
</asp:Content>

<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <asp:ScriptManagerProxy runat="server" id="ScriptManagerProxy">
</asp:ScriptManagerProxy>
<p></p>
<WebPartPages:XsltListViewWebPart runat="server" IsIncluded="True" GhostedXslLink="main.xsl" FrameType="None" NoDefaultStyle="TRUE" ViewFlag="8" Title="anouncment" PageType="PAGE_NORMALVIEW" ListName="{6AFAD193-ECB4-4837-B0FC-D60B7B96C64B}" Default="FALSE" DisplayName="anouncment" __markuptype="vsattributemarkup" __WebPartId="{3D3D168F-9906-447A-993C-9DAADCFAE114}" id="g_3d3d168f_9906_447a_993c_9daadcfae114" viewcontenttypeid="0x" __designer:customxsl="fldtypes_Ratings.xsl" __AllowXSLTEditing="true" WebPart="true" Height="" Width="">
<XmlDefinition>
	<View Name="{131F908A-72C1-4D62-B993-F85D59266E2C}" MobileView="TRUE" Type="HTML" DisplayName="All items" Url="/Lists/anouncment/AllItems.aspx" Level="1" BaseViewID="1" ContentTypeID="0x" ImageUrl="/_layouts/15/images/announce.png?rev=40">
		<Query/>
		<ViewFields>
			<FieldRef Name="LinkTitle"/>
			<FieldRef Name="Modified"/>
			<FieldRef Name="Body"/>
			<FieldRef Name="Expires"/>
		</ViewFields>
		<RowLimit Paged="TRUE">30</RowLimit>
		<Aggregations Value="Off"/>
		<JSLink>clienttemplates.js</JSLink>
		<XslLink Default="TRUE">main.xsl</XslLink>
		<Toolbar Type="Standard"/>
		<ViewStyle ID="12"/>
	</View>
</XmlDefinition>
<parameterbindings>
	<ParameterBinding Name="dvt_sortdir" Location="Postback;Connection"/>
	<ParameterBinding Name="dvt_sortfield" Location="Postback;Connection"/>
	<ParameterBinding Name="dvt_startposition" Location="Postback" DefaultValue=""/>
	<ParameterBinding Name="dvt_firstrow" Location="Postback;Connection"/>
	<ParameterBinding Name="OpenMenuKeyAccessible" Location="Resource(wss,OpenMenuKeyAccessible)" />
	<ParameterBinding Name="open_menu" Location="Resource(wss,open_menu)" />
	<ParameterBinding Name="select_deselect_all" Location="Resource(wss,select_deselect_all)" />
	<ParameterBinding Name="idPresEnabled" Location="Resource(wss,idPresEnabled)" />
	<ParameterBinding Name="NoAnnouncements" Location="Resource(wss,noXinviewofY_LIST)" />
	<ParameterBinding Name="NoAnnouncementsHowTo" Location="Resource(core,noXinviewofY_DEFAULT)" />
	<ParameterBinding Name="AddNewAnnouncement" Location="Resource(wss,addnewitem)" />
	<ParameterBinding Name="MoreAnnouncements" Location="Resource(wss,moreItemsParen)" />
</parameterbindings><xsl><xsl:stylesheet xmlns:x="http://www.w3.org/2001/XMLSchema" xmlns:d="http://schemas.microsoft.com/sharepoint/dsp" version="1.0" exclude-result-prefixes="xsl msxsl ddwrt" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:SharePoint="Microsoft.SharePoint.WebControls" xmlns:pcm="urn:PageContentManager" xmlns:ddwrt2="urn:frontpage:internal" xmlns:o="urn:schemas-microsoft-com:office:office" ddwrt:ghost="show_all"> 
  <xsl:include href="/_layouts/15/xsl/main.xsl"/> 
  <xsl:include href="/_layouts/15/xsl/internal.xsl"/> 
  	<xsl:param name="AllRows" select="/dsQueryResponse/Rows/Row[$EntityName = '' or (position() &gt;= $FirstRow and position() &lt;= $LastRow)]"/>
  	<xsl:param name="dvt_apos">&apos;</xsl:param>
	<xsl:template match="/" ddwrt:ghost="show" xmlns:ddwrt2="urn:frontpage:internal">
    	<xsl:variable name="LastRowValue">
        	<xsl:choose>
            	<xsl:when test="$EntityName = '' or $LastRow &lt; $RowTotalCount">
              <xsl:value-of select="$LastRow"/>	
            </xsl:when>
            	<xsl:otherwise>
              <xsl:value-of select="$RowTotalCount"/>
            </xsl:otherwise>
        	</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="NextRow">
      <xsl:value-of select="$LastRowValue + 1"/>
    </xsl:variable>
		<xsl:choose>
    		<xsl:when test="$ForRenderListData='1'">
      <rows>
        <xsl:variable name="Fields" select="$XmlDefinition/ViewFields/FieldRef[not(@Explicit='TRUE')]"/>
        <xsl:for-each select="$AllRows">
          	<xsl:variable name="thisNode" select="."/>
        	<xsl:variable name="ID">
            	<xsl:call-template name="ResolveId">
                	<xsl:with-param name="thisNode" select ="$thisNode"/>
            	</xsl:call-template>
        </xsl:variable>
          <row id="{$ID}">
            <xsl:for-each select="$Fields">
              	<xsl:if test="./@XSLRender='1'">
                <field rowid="{$ID}" name="{./@Name}">
                  	<xsl:text disable-output-escaping="yes">&lt;![CDATA[</xsl:text>
                  <xsl:apply-templates select="." mode="PrintFieldWithDisplayFormLink">
                    <xsl:with-param name="thisNode" select="$thisNode"/>
                  </xsl:apply-templates>
                  	<xsl:text disable-output-escaping="yes">]]&gt;</xsl:text>
                </field>
              </xsl:if>
            </xsl:for-each>
          </row>
        </xsl:for-each>
      </rows>
    </xsl:when>
    		<xsl:when test="$RenderCTXOnly='True'">
				<xsl:call-template name="CTXGeneration"/>
	  </xsl:when>
	  		<xsl:when test="($ManualRefresh = 'True')">
				<xsl:call-template name="AjaxWrapper" />
	  </xsl:when>
	  		<xsl:otherwise>
		<xsl:apply-templates mode="RootTemplate" select="$XmlDefinition"/>
	  </xsl:otherwise>
		</xsl:choose>
	  	<xsl:if test="$ClientRender='1'">
      		<xsl:call-template name="GenerateCSRCalls"/>
	  </xsl:if>
  </xsl:template>
	<xsl:template name="View_Default_RootTemplate" mode="RootTemplate" match="View" ddwrt:dvt_mode="root" ddwrt:ghost="hide">
    	<xsl:param name="ShowSelectAllCheckbox" select="'True'"/>
    	<xsl:if test="($IsGhosted = '0' and $MasterVersion=3 and Toolbar[@Type='Standard']) or $ShowAlways">
      		<xsl:call-template name="ListViewToolbar"/>
    </xsl:if>
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
      	<xsl:if test="not($NoCTX)">
        	<xsl:call-template name="CTXGeneration"/>
      </xsl:if>
      	<xsl:if test="List/@TemplateType=109 and not($ClientRender='1')">
        	<xsl:call-template name="PicLibScriptGeneration"/>
      </xsl:if>
      <tr>
        <td id="script{$ContainerId}">
          	<xsl:if test="not($ClientRender='1')">
            	<xsl:if test="not($NoAJAX)">
              <iframe src="javascript:false;" id="FilterIframe{$ViewCounter}" name="FilterIframe{$ViewCounter}" style="display:none" height="0" width="0" FilterLink="{$FilterLink}"></iframe>
            </xsl:if>
            <table summary="{List/@title} {List/@description}" xmlns:o="urn:schemas-microsoft-com:office:office" o:WebQuerySourceHref="{$HttpPath}&amp;XMLDATA=1&amp;RowLimit=0&amp;View={$View}"
                            width="100%" border="0" cellspacing="0" dir="{List/@Direction}">
              	<xsl:if test="not($NoCTX)">
                	<xsl:attribute name="onmouseover">
                  EnsureSelectionHandler(event,this,<xsl:value-of select ="$ViewCounter"/>)
                </xsl:attribute>
              </xsl:if>
              	<xsl:if test="$NoAJAX">
                	<xsl:attribute name="FilterLink">
                  <xsl:value-of select="$FilterLink"/>
                </xsl:attribute>
              </xsl:if>
              	<xsl:attribute name="cellpadding">
                	<xsl:choose>
                  		<xsl:when test="ViewStyle/@ID='15' or ViewStyle/@ID='16'">0</xsl:when>
                  		<xsl:otherwise>1</xsl:otherwise>
                	</xsl:choose>
              </xsl:attribute>
              	<xsl:attribute name="id">
                	<xsl:choose>
                  		<xsl:when test="$IsDocLib or dvt_RowCount = 0">onetidDoclibViewTbl0</xsl:when>
                  		<xsl:otherwise>
                    <xsl:value-of select="concat($List, '-', $View)"/>
                  </xsl:otherwise>
                	</xsl:choose>
              </xsl:attribute>
              	<xsl:attribute name="class">
                	<xsl:choose>
                  		<xsl:when test="ViewStyle/@ID='0' or ViewStyle/@ID='17'">
                    <xsl:value-of select="$ViewClassName"/> ms-basictable
                  </xsl:when>
                  		<xsl:otherwise>
                    <xsl:value-of select="$ViewClassName"/>
                  </xsl:otherwise>
                	</xsl:choose>
              </xsl:attribute>
              	<xsl:if test="$InlineEdit">
                	<xsl:attribute name="inlineedit">
                  javascript: <xsl:value-of select="ddwrt:GenFireServerEvent('__cancel;dvt_form_key={@ID}')"/>;CoreInvoke('ExpGroupOnPageLoad', 'true');
                </xsl:attribute>
              </xsl:if>
              <xsl:apply-templates select="." mode="full">
                <xsl:with-param name="ShowSelectAllCheckbox" select="$ShowSelectAllCheckbox"/>
              </xsl:apply-templates>
            </table>
          </xsl:if>          
        </td>
      </tr>
      	<xsl:if test="not($ClientRender='1') and $dvt_RowCount = 0 and not (@BaseViewID='3' and List/@TemplateType='102')">
        <tr>
          <td>
             <table width="100%" border="0" dir="{List/@Direction}">
               	<xsl:call-template name="EmptyTemplate" />
             </table>
          </td>
        </tr>
      </xsl:if>
    </table>
    	<xsl:choose>
        	<xsl:when test="$ClientRender='1'">
           <div id="scriptPaging{$ContainerId}"/>
        </xsl:when>
        	<xsl:otherwise>
        		<xsl:call-template name="pagingButtons" />
        		<xsl:if test="Toolbar[@Type='Freeform'] or ($MasterVersion>=4 and Toolbar[@Type='Standard'])">
          			<xsl:call-template name="Freeform">
            			<xsl:with-param name="AddNewText">
              				<xsl:choose>
                				<xsl:when test="List/@TemplateType='104'">
                  <xsl:value-of select="$Rows/@resource.wss.idHomePageNewAnnounce"/>
                </xsl:when>
                				<xsl:when test="List/@TemplateType='101' or List/@TemplateType='115'">
                  <xsl:value-of select="$Rows/@resource.wss.Add_New_Document"/>
                </xsl:when>
                				<xsl:when test="List/@TemplateType='103'">
                  <xsl:value-of select="$Rows/@resource.wss.AddNewLink"/>
                </xsl:when>
                				<xsl:when test="List/@TemplateType='106'">
                  <xsl:value-of select="$Rows/@resource.wss.AddNewEvent"/>
                </xsl:when>
                				<xsl:when test="List/@TemplateType='119'">
                  <xsl:value-of select="$Rows/@resource.wss.AddNewWikiPage"/>
                </xsl:when>
                				<xsl:otherwise>
                  <xsl:value-of select="$Rows/@resource.wss.addnewitem"/>
                </xsl:otherwise>
              				</xsl:choose>
            </xsl:with-param>
            			<xsl:with-param name="ID">
              				<xsl:choose>
              					<xsl:when test="List/@TemplateType='104'">idHomePageNewAnnouncement</xsl:when>
              					<xsl:when test="List/@TemplateType='101'">idHomePageNewDocument</xsl:when>
              					<xsl:when test="List/@TemplateType='103'">idHomePageNewLink</xsl:when>
              					<xsl:when test="List/@TemplateType='106'">idHomePageNewEvent</xsl:when>
              					<xsl:when test="List/@TemplateType='119'">idHomePageNewWikiPage</xsl:when>
              					<xsl:otherwise>idHomePageNewItem</xsl:otherwise>
              				</xsl:choose>
            </xsl:with-param>
          			</xsl:call-template>
        </xsl:if>
        </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template match="View[ViewStyle/@ID='12' or ViewStyle/@ID='13' or ViewStyle/@ID='18' or ViewStyle/@ID='19']" mode="full" ddwrt:ghost="hide">
    <tr>
      <td colspan="3">
        <table border="0" cellPadding="0" cellSpacing="0" width="100%">
          <tr valign="top" class="ms-viewheadertr">
            <xsl:if test="not($GroupingRender)">
              <xsl:apply-templates mode="header" select="ViewFields/FieldRef[not(@Explicit='TRUE')]"/>
            </xsl:if>
          </tr>
        </table>
      </td>
    </tr>
    <xsl:apply-templates select="." mode="RenderView" />
  </xsl:template>
	<xsl:template name="FieldRef_header.LinkTitle" ddwrt:dvt_mode="header" match="FieldRef[@Name='LinkTitle']" mode="header" ddwrt:ghost="hide">
    <th nowrap="nowrap" scope="col" onmouseover="OnChildColumn(this)">
      <xsl:attribute name="class">
        <xsl:choose>
          	<xsl:when test="(@Type='User' or @Type='UserMulti') and ($PresenceEnabled='1')">ms-vh</xsl:when>
          	<xsl:otherwise>ms-vh2</xsl:otherwise>
         </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="dvt_headerfield.LinkTitle">
        <xsl:with-param name="fieldname">
          <xsl:value-of select="@Name"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtitle">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="displayname">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtype">
          	<xsl:choose>
            	<xsl:when test="@Type='Number' or @Type='Currency'">number</xsl:when>
            	<xsl:otherwise>x:string</xsl:otherwise>
          	</xsl:choose>
        </xsl:with-param>
      </xsl:call-template>
    </th>
  </xsl:template>
	<xsl:template name="dvt_headerfield.LinkTitle" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:variable name="separator" select="' '" />
    	<xsl:variable name="connector" select="';'" />
    	<xsl:variable name="linkdir">
      		<xsl:choose>
        		<xsl:when test="$dvt_sortfield = $fieldname and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
        		<xsl:otherwise>Asc</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="jsescapeddisplayname">
      		<xsl:call-template name="fixQuotes">
        		<xsl:with-param name="string" select="$displayname"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$MasterVersion &gt;=4 and not($NoAJAX)">
        <div Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
             DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
             class="ms-vh-div">
          	<xsl:call-template name="headerfield.LinkTitle">
            	<xsl:with-param name="fieldname" select ="$fieldname" />
            	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
            	<xsl:with-param name="displayname" select="$displayname" />
            	<xsl:with-param name="fieldtype" select="$fieldtype"/>
          	</xsl:call-template>
        </div>
      			<xsl:if test="(not($sortable='FALSE') and not(@FieldType='MultiChoice')) or (not(@Filterable='FALSE') and not(@FieldType='Note') and not(@FieldType='URL'))">
        <div class="s4-ctx">
          <span>&#160;</span>
            <a onfocus="OnChildColumn(this.parentNode.parentNode); return false;" class="ms-headerSortArrowLink" onclick="PopMenuFromChevron(event); return false;" href="javascript:;" title="{$open_menu}">
            </a>
          <span>&#160;</span>
        </div>
      </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:attribute name="style">padding:0 !important;border:0 !important;</xsl:attribute>
        <div style="width:100%;position:relative;left:0;top:0;margin:0;border:0">
          	<xsl:choose>
            	<xsl:when test="$NoAJAX">
              <table CtxNum="{$ViewCounter}" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" name="{$fieldname}" DisplayName="{$displayname}" height="100%">
                <xsl:choose>
                  	<xsl:when test="$MasterVersion &gt;=4">
                    	<xsl:attribute name="style">width:100%;height:27px</xsl:attribute>
                  </xsl:when>
                  	<xsl:otherwise>
                    	<xsl:attribute name="style">width:100%</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$sortable='FALSE'">
                  	<xsl:attribute name="Sortable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@Filterable='FALSE'">
                  	<xsl:attribute name="Filterable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@FilterDisableMessage">
                  	<xsl:attribute name="FilterDisableMessage">
                    <xsl:value-of select="@FilterDisableMessage" />
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="not($sortable='FALSE') or not(@Filterable='FALSE')">
                  	<xsl:attribute name="onmouseover">
                    	<xsl:text disable-output-escaping="yes">OnMouseOverAdHocFilter(this, '</xsl:text>
                    <xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" />
                    	<xsl:text disable-output-escaping="yes">' , '', '')</xsl:text>
                  </xsl:attribute>
                  	<xsl:attribute name="SortFields"><xsl:value-of select="concat($RootFolderParam,$FieldSortParam,'SortField=',@Name,'&amp;SortDir=',$linkdir)"/></xsl:attribute>
                  	<xsl:attribute name="FieldType"><xsl:value-of select="@FieldType"/></xsl:attribute>
                  	<xsl:attribute name="ResultType"><xsl:value-of select="@ResultType"/></xsl:attribute>
                </xsl:if>
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:when>
            	<xsl:otherwise>
              <table style="width:100%;" Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
                 DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
                 height="100%" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" onmouseover="OnMouseOverFilter(this)">
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:otherwise>
          	</xsl:choose>
        </div>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="headerfield.LinkTitle" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:choose>
      		<xsl:when test="$Filter='1'">
        <xsl:value-of select ="$Rows/@filter.render" disable-output-escaping ="yes"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="(@ImnHeader='TRUE') and ($PresenceEnabled='1')">
            <table cellpadding="0" cellspacing="0" dir="{$XmlDefinition/List/@Direction}">
              <tr>
                <td class="ms-imnImgTD">
                  <img border="0" valign="middle" height="12" width="12" altbase="{$idPresEnabled}" src="/_layouts/15/images/blank.gif?rev=40" onload="IMNRegisterHeader(event)" id="imnhdr{position()}"/>
                </td>
                <td nowrap="nowrap" class="ms-vh ms-imnTxtTD">
                  	<xsl:call-template name="FieldHeader.LinkTitle">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </td>
              </tr>
            </table>
          </xsl:when>
          			<xsl:otherwise>
            			<xsl:choose>
              				<xsl:when test="$fieldtype='number'">
                <div align="right" class="ms-numHeader">
                  	<xsl:call-template name="FieldHeader.LinkTitle">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </div>
              </xsl:when>
              				<xsl:otherwise>
                				<xsl:call-template name="FieldHeader.LinkTitle">
                  					<xsl:with-param name="fieldname" select="$fieldname"/>
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                  					<xsl:with-param name="displayname" select="$displayname"/>
                  					<xsl:with-param name="fieldtype" select="$fieldtype"/>
                				</xsl:call-template>
              </xsl:otherwise>
            			</xsl:choose>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldHeader.LinkTitle" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname" />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:param name="thisNode" select="."/>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="not($sortable='FALSE')">
        		<xsl:variable name="sortfield">
          			<xsl:choose>
            			<xsl:when test="substring($fieldname, string-length($fieldname) - 5) = '(text)'">
              <xsl:value-of select="substring($fieldname, 1, string-length($fieldname) - 6)" />
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="$fieldname"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="linkdir">
          			<xsl:choose>
            			<xsl:when test="$dvt_sortfield = $sortfield and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
            			<xsl:otherwise>Asc</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="sortText">
          			<xsl:choose>
            			<xsl:when test="$linkdir='Desc'">&apos; + &apos;descending&apos; + &apos;</xsl:when>
            			<xsl:otherwise>&apos; + &apos;ascending&apos; + &apos;</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="jsescapeddisplayname">
          			<xsl:call-template name="fixQuotes">
            			<xsl:with-param name="string" select="$displayname"/>
          			</xsl:call-template>
        </xsl:variable>
        		<xsl:variable name="separator" select="' '" />
        		<xsl:variable name="connector" select="';'" />
        <a id="diidSort{$ViewCounter}{$fieldname}" class="ms-headerSortTitleLink" onfocus="OnFocusFilter(this)">
          		<xsl:attribute name="href">javascript: <xsl:if test="$NoAJAX">
              		<xsl:call-template name="GenFireServerEvent">
                		<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                		<xsl:with-param name="apos">'</xsl:with-param>
              		</xsl:call-template>
            </xsl:if>
          </xsl:attribute>
          		<xsl:attribute name="onclick">
            		<xsl:choose>
              			<xsl:when test="not($NoAJAX)">javascript:return OnClickFilter(this,event);</xsl:when>
              			<xsl:otherwise>javascript: <xsl:call-template name="GenFireServerEvent">
                  			<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                  			<xsl:with-param name="apos">'</xsl:with-param>
                			</xsl:call-template>; event.cancelBubble = true; return false;</xsl:otherwise>
            		</xsl:choose>
          </xsl:attribute>
          		<xsl:choose>
            		<xsl:when test="not($NoAJAX)">
              			<xsl:attribute name="SortingFields"><xsl:value-of select ="$RootFolderParam"/><xsl:value-of select ="$FieldSortParam"/>SortField=<xsl:value-of select="@Name"/>&amp;SortDir=<xsl:value-of select="$linkdir"/></xsl:attribute>
            </xsl:when>
            		<xsl:otherwise>
              			<xsl:attribute name="FilterString"><xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" /></xsl:attribute>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:choose>
            		<xsl:when test="$fieldtype = 'Attachments'">
              <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
            </xsl:when>
            		<xsl:otherwise>
              <xsl:value-of select="$fieldtitle"/>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:if test="$dvt_sortfield = $sortfield">
            		<xsl:choose>
              			<xsl:when test="$dvt_sortdir = 'ascending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortAsc}" src="{ddwrt:FieldSortImageUrl('Desc')}" />
              </xsl:when>
              			<xsl:when test="$dvt_sortdir = 'descending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortDesc}" src="{ddwrt:FieldSortImageUrl('Asc')}" />
              </xsl:when>
            		</xsl:choose>
          </xsl:if>
          <img src="/_layouts/15/images/blank.gif?rev=40" class="ms-hidden" border="0" width="1" height="1" alt=""/>
        </a>
        <img src="/_layouts/15/images/blank.gif?rev=40" alt="" border="0"/>
        		<xsl:choose>
          			<xsl:when test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
            <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
          </xsl:when>
          			<xsl:otherwise>
            <img src="/_layouts/15/images/blank.gif?rev=40" border="0" alt=""/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:when>
      		<xsl:when test="not(@Filterable='FALSE') and ($sortable='FALSE')">
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
          <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="($fieldtype='BusinessData') and not($XmlDefinition/List/@ExternalDataList='1')">
      <a style="padding-left:2px;padding-right:12px" onmouseover="" onclick="GoToLink(this);return false;"
        href="{$HttpVDir}/_layouts/15/BusinessDataSynchronizer.aspx?ListId={$List}&amp;ColumnName={$fieldname}">
        <img border="0" src="/_layouts/15/images/bdupdate.gif?rev=40" alt="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}" title="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}"/>
      </a>
    </xsl:if>
  </xsl:template>
	<xsl:template name="FieldRef_DateTime_header.Modified" ddwrt:dvt_mode="header" match="FieldRef[(@Type='DateTime') and @Name='Modified']" mode="header" ddwrt:ghost="hide">
    <th class="ms-vh2" nowrap="nowrap" scope="col" onmouseover="OnChildColumn(this)">
      <xsl:call-template name="dvt_headerfield.Modified">
        <xsl:with-param name="fieldname">
          <xsl:value-of select="@Name"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtitle">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="displayname">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtype">x:datetime</xsl:with-param>
      </xsl:call-template>
    </th>
  </xsl:template>
	<xsl:template name="dvt_headerfield.Modified" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:variable name="separator" select="' '" />
    	<xsl:variable name="connector" select="';'" />
    	<xsl:variable name="linkdir">
      		<xsl:choose>
        		<xsl:when test="$dvt_sortfield = $fieldname and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
        		<xsl:otherwise>Asc</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="jsescapeddisplayname">
      		<xsl:call-template name="fixQuotes">
        		<xsl:with-param name="string" select="$displayname"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$MasterVersion &gt;=4 and not($NoAJAX)">
        <div Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
             DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
             class="ms-vh-div">
          	<xsl:call-template name="headerfield.Modified">
            	<xsl:with-param name="fieldname" select ="$fieldname" />
            	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
            	<xsl:with-param name="displayname" select="$displayname" />
            	<xsl:with-param name="fieldtype" select="$fieldtype"/>
          	</xsl:call-template>
        </div>
      			<xsl:if test="(not($sortable='FALSE') and not(@FieldType='MultiChoice')) or (not(@Filterable='FALSE') and not(@FieldType='Note') and not(@FieldType='URL'))">
        <div class="s4-ctx">
          <span>&#160;</span>
            <a onfocus="OnChildColumn(this.parentNode.parentNode); return false;" class="ms-headerSortArrowLink" onclick="PopMenuFromChevron(event); return false;" href="javascript:;" title="{$open_menu}">
            </a>
          <span>&#160;</span>
        </div>
      </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:attribute name="style">padding:0 !important;border:0 !important;</xsl:attribute>
        <div style="width:100%;position:relative;left:0;top:0;margin:0;border:0">
          	<xsl:choose>
            	<xsl:when test="$NoAJAX">
              <table CtxNum="{$ViewCounter}" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" name="{$fieldname}" DisplayName="{$displayname}" height="100%">
                <xsl:choose>
                  	<xsl:when test="$MasterVersion &gt;=4">
                    	<xsl:attribute name="style">width:100%;height:27px</xsl:attribute>
                  </xsl:when>
                  	<xsl:otherwise>
                    	<xsl:attribute name="style">width:100%</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$sortable='FALSE'">
                  	<xsl:attribute name="Sortable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@Filterable='FALSE'">
                  	<xsl:attribute name="Filterable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@FilterDisableMessage">
                  	<xsl:attribute name="FilterDisableMessage">
                    <xsl:value-of select="@FilterDisableMessage" />
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="not($sortable='FALSE') or not(@Filterable='FALSE')">
                  	<xsl:attribute name="onmouseover">
                    	<xsl:text disable-output-escaping="yes">OnMouseOverAdHocFilter(this, '</xsl:text>
                    <xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" />
                    	<xsl:text disable-output-escaping="yes">' , '', '')</xsl:text>
                  </xsl:attribute>
                  	<xsl:attribute name="SortFields"><xsl:value-of select="concat($RootFolderParam,$FieldSortParam,'SortField=',@Name,'&amp;SortDir=',$linkdir)"/></xsl:attribute>
                  	<xsl:attribute name="FieldType"><xsl:value-of select="@FieldType"/></xsl:attribute>
                  	<xsl:attribute name="ResultType"><xsl:value-of select="@ResultType"/></xsl:attribute>
                </xsl:if>
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:when>
            	<xsl:otherwise>
              <table style="width:100%;" Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
                 DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
                 height="100%" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" onmouseover="OnMouseOverFilter(this)">
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:otherwise>
          	</xsl:choose>
        </div>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="headerfield.Modified" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:choose>
      		<xsl:when test="$Filter='1'">
        <xsl:value-of select ="$Rows/@filter.render" disable-output-escaping ="yes"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="(@ImnHeader='TRUE') and ($PresenceEnabled='1')">
            <table cellpadding="0" cellspacing="0" dir="{$XmlDefinition/List/@Direction}">
              <tr>
                <td class="ms-imnImgTD">
                  <img border="0" valign="middle" height="12" width="12" altbase="{$idPresEnabled}" src="/_layouts/15/images/blank.gif?rev=40" onload="IMNRegisterHeader(event)" id="imnhdr{position()}"/>
                </td>
                <td nowrap="nowrap" class="ms-vh ms-imnTxtTD">
                  	<xsl:call-template name="FieldHeader.Modified">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </td>
              </tr>
            </table>
          </xsl:when>
          			<xsl:otherwise>
            			<xsl:choose>
              				<xsl:when test="$fieldtype='number'">
                <div align="right" class="ms-numHeader">
                  	<xsl:call-template name="FieldHeader.Modified">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </div>
              </xsl:when>
              				<xsl:otherwise>
                				<xsl:call-template name="FieldHeader.Modified">
                  					<xsl:with-param name="fieldname" select="$fieldname"/>
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                  					<xsl:with-param name="displayname" select="$displayname"/>
                  					<xsl:with-param name="fieldtype" select="$fieldtype"/>
                				</xsl:call-template>
              </xsl:otherwise>
            			</xsl:choose>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldHeader.Modified" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname" />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:param name="thisNode" select="."/>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="not($sortable='FALSE')">
        		<xsl:variable name="sortfield">
          			<xsl:choose>
            			<xsl:when test="substring($fieldname, string-length($fieldname) - 5) = '(text)'">
              <xsl:value-of select="substring($fieldname, 1, string-length($fieldname) - 6)" />
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="$fieldname"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="linkdir">
          			<xsl:choose>
            			<xsl:when test="$dvt_sortfield = $sortfield and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
            			<xsl:otherwise>Asc</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="sortText">
          			<xsl:choose>
            			<xsl:when test="$linkdir='Desc'">&apos; + &apos;descending&apos; + &apos;</xsl:when>
            			<xsl:otherwise>&apos; + &apos;ascending&apos; + &apos;</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="jsescapeddisplayname">
          			<xsl:call-template name="fixQuotes">
            			<xsl:with-param name="string" select="$displayname"/>
          			</xsl:call-template>
        </xsl:variable>
        		<xsl:variable name="separator" select="' '" />
        		<xsl:variable name="connector" select="';'" />
        <a id="diidSort{$ViewCounter}{$fieldname}" class="ms-headerSortTitleLink" onfocus="OnFocusFilter(this)">
          		<xsl:attribute name="href">javascript: <xsl:if test="$NoAJAX">
              		<xsl:call-template name="GenFireServerEvent">
                		<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                		<xsl:with-param name="apos">'</xsl:with-param>
              		</xsl:call-template>
            </xsl:if>
          </xsl:attribute>
          		<xsl:attribute name="onclick">
            		<xsl:choose>
              			<xsl:when test="not($NoAJAX)">javascript:return OnClickFilter(this,event);</xsl:when>
              			<xsl:otherwise>javascript: <xsl:call-template name="GenFireServerEvent">
                  			<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                  			<xsl:with-param name="apos">'</xsl:with-param>
                			</xsl:call-template>; event.cancelBubble = true; return false;</xsl:otherwise>
            		</xsl:choose>
          </xsl:attribute>
          		<xsl:choose>
            		<xsl:when test="not($NoAJAX)">
              			<xsl:attribute name="SortingFields"><xsl:value-of select ="$RootFolderParam"/><xsl:value-of select ="$FieldSortParam"/>SortField=<xsl:value-of select="@Name"/>&amp;SortDir=<xsl:value-of select="$linkdir"/></xsl:attribute>
            </xsl:when>
            		<xsl:otherwise>
              			<xsl:attribute name="FilterString"><xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" /></xsl:attribute>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:choose>
            		<xsl:when test="$fieldtype = 'Attachments'">
              <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
            </xsl:when>
            		<xsl:otherwise>
              <xsl:value-of select="$fieldtitle"/>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:if test="$dvt_sortfield = $sortfield">
            		<xsl:choose>
              			<xsl:when test="$dvt_sortdir = 'ascending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortAsc}" src="{ddwrt:FieldSortImageUrl('Desc')}" />
              </xsl:when>
              			<xsl:when test="$dvt_sortdir = 'descending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortDesc}" src="{ddwrt:FieldSortImageUrl('Asc')}" />
              </xsl:when>
            		</xsl:choose>
          </xsl:if>
          <img src="/_layouts/15/images/blank.gif?rev=40" class="ms-hidden" border="0" width="1" height="1" alt=""/>
        </a>
        <img src="/_layouts/15/images/blank.gif?rev=40" alt="" border="0"/>
        		<xsl:choose>
          			<xsl:when test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
            <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
          </xsl:when>
          			<xsl:otherwise>
            <img src="/_layouts/15/images/blank.gif?rev=40" border="0" alt=""/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:when>
      		<xsl:when test="not(@Filterable='FALSE') and ($sortable='FALSE')">
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
          <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="($fieldtype='BusinessData') and not($XmlDefinition/List/@ExternalDataList='1')">
      <a style="padding-left:2px;padding-right:12px" onmouseover="" onclick="GoToLink(this);return false;"
        href="{$HttpVDir}/_layouts/15/BusinessDataSynchronizer.aspx?ListId={$List}&amp;ColumnName={$fieldname}">
        <img border="0" src="/_layouts/15/images/bdupdate.gif?rev=40" alt="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}" title="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}"/>
      </a>
    </xsl:if>
  </xsl:template>
	<xsl:template name="FieldRef_header.Body" ddwrt:dvt_mode="header" match="FieldRef[@Name='Body']" mode="header" ddwrt:ghost="hide">
    <th nowrap="nowrap" scope="col" onmouseover="OnChildColumn(this)">
      <xsl:attribute name="class">
        <xsl:choose>
          	<xsl:when test="(@Type='User' or @Type='UserMulti') and ($PresenceEnabled='1')">ms-vh</xsl:when>
          	<xsl:otherwise>ms-vh2</xsl:otherwise>
         </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="dvt_headerfield.Body">
        <xsl:with-param name="fieldname">
          <xsl:value-of select="@Name"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtitle">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="displayname">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtype">
          	<xsl:choose>
            	<xsl:when test="@Type='Number' or @Type='Currency'">number</xsl:when>
            	<xsl:otherwise>x:string</xsl:otherwise>
          	</xsl:choose>
        </xsl:with-param>
      </xsl:call-template>
    </th>
  </xsl:template>
	<xsl:template name="dvt_headerfield.Body" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:variable name="separator" select="' '" />
    	<xsl:variable name="connector" select="';'" />
    	<xsl:variable name="linkdir">
      		<xsl:choose>
        		<xsl:when test="$dvt_sortfield = $fieldname and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
        		<xsl:otherwise>Asc</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="jsescapeddisplayname">
      		<xsl:call-template name="fixQuotes">
        		<xsl:with-param name="string" select="$displayname"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$MasterVersion &gt;=4 and not($NoAJAX)">
        <div Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
             DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
             class="ms-vh-div">
          	<xsl:call-template name="headerfield.Body">
            	<xsl:with-param name="fieldname" select ="$fieldname" />
            	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
            	<xsl:with-param name="displayname" select="$displayname" />
            	<xsl:with-param name="fieldtype" select="$fieldtype"/>
          	</xsl:call-template>
        </div>
      			<xsl:if test="(not($sortable='FALSE') and not(@FieldType='MultiChoice')) or (not(@Filterable='FALSE') and not(@FieldType='Note') and not(@FieldType='URL'))">
        <div class="s4-ctx">
          <span>&#160;</span>
            <a onfocus="OnChildColumn(this.parentNode.parentNode); return false;" class="ms-headerSortArrowLink" onclick="PopMenuFromChevron(event); return false;" href="javascript:;" title="{$open_menu}">
            </a>
          <span>&#160;</span>
        </div>
      </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:attribute name="style">padding:0 !important;border:0 !important;</xsl:attribute>
        <div style="width:100%;position:relative;left:0;top:0;margin:0;border:0">
          	<xsl:choose>
            	<xsl:when test="$NoAJAX">
              <table CtxNum="{$ViewCounter}" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" name="{$fieldname}" DisplayName="{$displayname}" height="100%">
                <xsl:choose>
                  	<xsl:when test="$MasterVersion &gt;=4">
                    	<xsl:attribute name="style">width:100%;height:27px</xsl:attribute>
                  </xsl:when>
                  	<xsl:otherwise>
                    	<xsl:attribute name="style">width:100%</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$sortable='FALSE'">
                  	<xsl:attribute name="Sortable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@Filterable='FALSE'">
                  	<xsl:attribute name="Filterable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@FilterDisableMessage">
                  	<xsl:attribute name="FilterDisableMessage">
                    <xsl:value-of select="@FilterDisableMessage" />
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="not($sortable='FALSE') or not(@Filterable='FALSE')">
                  	<xsl:attribute name="onmouseover">
                    	<xsl:text disable-output-escaping="yes">OnMouseOverAdHocFilter(this, '</xsl:text>
                    <xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" />
                    	<xsl:text disable-output-escaping="yes">' , '', '')</xsl:text>
                  </xsl:attribute>
                  	<xsl:attribute name="SortFields"><xsl:value-of select="concat($RootFolderParam,$FieldSortParam,'SortField=',@Name,'&amp;SortDir=',$linkdir)"/></xsl:attribute>
                  	<xsl:attribute name="FieldType"><xsl:value-of select="@FieldType"/></xsl:attribute>
                  	<xsl:attribute name="ResultType"><xsl:value-of select="@ResultType"/></xsl:attribute>
                </xsl:if>
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:when>
            	<xsl:otherwise>
              <table style="width:100%;" Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
                 DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
                 height="100%" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" onmouseover="OnMouseOverFilter(this)">
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:otherwise>
          	</xsl:choose>
        </div>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="headerfield.Body" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:choose>
      		<xsl:when test="$Filter='1'">
        <xsl:value-of select ="$Rows/@filter.render" disable-output-escaping ="yes"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="(@ImnHeader='TRUE') and ($PresenceEnabled='1')">
            <table cellpadding="0" cellspacing="0" dir="{$XmlDefinition/List/@Direction}">
              <tr>
                <td class="ms-imnImgTD">
                  <img border="0" valign="middle" height="12" width="12" altbase="{$idPresEnabled}" src="/_layouts/15/images/blank.gif?rev=40" onload="IMNRegisterHeader(event)" id="imnhdr{position()}"/>
                </td>
                <td nowrap="nowrap" class="ms-vh ms-imnTxtTD">
                  	<xsl:call-template name="FieldHeader.Body">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </td>
              </tr>
            </table>
          </xsl:when>
          			<xsl:otherwise>
            			<xsl:choose>
              				<xsl:when test="$fieldtype='number'">
                <div align="right" class="ms-numHeader">
                  	<xsl:call-template name="FieldHeader.Body">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </div>
              </xsl:when>
              				<xsl:otherwise>
                				<xsl:call-template name="FieldHeader.Body">
                  					<xsl:with-param name="fieldname" select="$fieldname"/>
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                  					<xsl:with-param name="displayname" select="$displayname"/>
                  					<xsl:with-param name="fieldtype" select="$fieldtype"/>
                				</xsl:call-template>
              </xsl:otherwise>
            			</xsl:choose>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldHeader.Body" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname" />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:param name="thisNode" select="."/>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="not($sortable='FALSE')">
        		<xsl:variable name="sortfield">
          			<xsl:choose>
            			<xsl:when test="substring($fieldname, string-length($fieldname) - 5) = '(text)'">
              <xsl:value-of select="substring($fieldname, 1, string-length($fieldname) - 6)" />
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="$fieldname"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="linkdir">
          			<xsl:choose>
            			<xsl:when test="$dvt_sortfield = $sortfield and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
            			<xsl:otherwise>Asc</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="sortText">
          			<xsl:choose>
            			<xsl:when test="$linkdir='Desc'">&apos; + &apos;descending&apos; + &apos;</xsl:when>
            			<xsl:otherwise>&apos; + &apos;ascending&apos; + &apos;</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="jsescapeddisplayname">
          			<xsl:call-template name="fixQuotes">
            			<xsl:with-param name="string" select="$displayname"/>
          			</xsl:call-template>
        </xsl:variable>
        		<xsl:variable name="separator" select="' '" />
        		<xsl:variable name="connector" select="';'" />
        <a id="diidSort{$ViewCounter}{$fieldname}" class="ms-headerSortTitleLink" onfocus="OnFocusFilter(this)">
          		<xsl:attribute name="href">javascript: <xsl:if test="$NoAJAX">
              		<xsl:call-template name="GenFireServerEvent">
                		<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                		<xsl:with-param name="apos">'</xsl:with-param>
              		</xsl:call-template>
            </xsl:if>
          </xsl:attribute>
          		<xsl:attribute name="onclick">
            		<xsl:choose>
              			<xsl:when test="not($NoAJAX)">javascript:return OnClickFilter(this,event);</xsl:when>
              			<xsl:otherwise>javascript: <xsl:call-template name="GenFireServerEvent">
                  			<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                  			<xsl:with-param name="apos">'</xsl:with-param>
                			</xsl:call-template>; event.cancelBubble = true; return false;</xsl:otherwise>
            		</xsl:choose>
          </xsl:attribute>
          		<xsl:choose>
            		<xsl:when test="not($NoAJAX)">
              			<xsl:attribute name="SortingFields"><xsl:value-of select ="$RootFolderParam"/><xsl:value-of select ="$FieldSortParam"/>SortField=<xsl:value-of select="@Name"/>&amp;SortDir=<xsl:value-of select="$linkdir"/></xsl:attribute>
            </xsl:when>
            		<xsl:otherwise>
              			<xsl:attribute name="FilterString"><xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" /></xsl:attribute>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:choose>
            		<xsl:when test="$fieldtype = 'Attachments'">
              <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
            </xsl:when>
            		<xsl:otherwise>
              <xsl:value-of select="$fieldtitle"/>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:if test="$dvt_sortfield = $sortfield">
            		<xsl:choose>
              			<xsl:when test="$dvt_sortdir = 'ascending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortAsc}" src="{ddwrt:FieldSortImageUrl('Desc')}" />
              </xsl:when>
              			<xsl:when test="$dvt_sortdir = 'descending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortDesc}" src="{ddwrt:FieldSortImageUrl('Asc')}" />
              </xsl:when>
            		</xsl:choose>
          </xsl:if>
          <img src="/_layouts/15/images/blank.gif?rev=40" class="ms-hidden" border="0" width="1" height="1" alt=""/>
        </a>
        <img src="/_layouts/15/images/blank.gif?rev=40" alt="" border="0"/>
        		<xsl:choose>
          			<xsl:when test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
            <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
          </xsl:when>
          			<xsl:otherwise>
            <img src="/_layouts/15/images/blank.gif?rev=40" border="0" alt=""/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:when>
      		<xsl:when test="not(@Filterable='FALSE') and ($sortable='FALSE')">
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
          <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="($fieldtype='BusinessData') and not($XmlDefinition/List/@ExternalDataList='1')">
      <a style="padding-left:2px;padding-right:12px" onmouseover="" onclick="GoToLink(this);return false;"
        href="{$HttpVDir}/_layouts/15/BusinessDataSynchronizer.aspx?ListId={$List}&amp;ColumnName={$fieldname}">
        <img border="0" src="/_layouts/15/images/bdupdate.gif?rev=40" alt="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}" title="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}"/>
      </a>
    </xsl:if>
  </xsl:template>
	<xsl:template name="FieldRef_DateTime_header.Expires" ddwrt:dvt_mode="header" match="FieldRef[(@Type='DateTime') and @Name='Expires']" mode="header" ddwrt:ghost="hide">
    <th class="ms-vh2" nowrap="nowrap" scope="col" onmouseover="OnChildColumn(this)">
      <xsl:call-template name="dvt_headerfield.Expires">
        <xsl:with-param name="fieldname">
          <xsl:value-of select="@Name"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtitle">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="displayname">
          <xsl:value-of select="@DisplayName"/>
        </xsl:with-param>
        <xsl:with-param name="fieldtype">x:datetime</xsl:with-param>
      </xsl:call-template>
    </th>
  </xsl:template>
	<xsl:template name="dvt_headerfield.Expires" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:variable name="separator" select="' '" />
    	<xsl:variable name="connector" select="';'" />
    	<xsl:variable name="linkdir">
      		<xsl:choose>
        		<xsl:when test="$dvt_sortfield = $fieldname and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
        		<xsl:otherwise>Asc</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="jsescapeddisplayname">
      		<xsl:call-template name="fixQuotes">
        		<xsl:with-param name="string" select="$displayname"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$MasterVersion &gt;=4 and not($NoAJAX)">
        <div Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
             DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
             class="ms-vh-div">
          	<xsl:call-template name="headerfield.Expires">
            	<xsl:with-param name="fieldname" select ="$fieldname" />
            	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
            	<xsl:with-param name="displayname" select="$displayname" />
            	<xsl:with-param name="fieldtype" select="$fieldtype"/>
          	</xsl:call-template>
        </div>
      			<xsl:if test="(not($sortable='FALSE') and not(@FieldType='MultiChoice')) or (not(@Filterable='FALSE') and not(@FieldType='Note') and not(@FieldType='URL'))">
        <div class="s4-ctx">
          <span>&#160;</span>
            <a onfocus="OnChildColumn(this.parentNode.parentNode); return false;" class="ms-headerSortArrowLink" onclick="PopMenuFromChevron(event); return false;" href="javascript:;" title="{$open_menu}">
            </a>
          <span>&#160;</span>
        </div>
      </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:attribute name="style">padding:0 !important;border:0 !important;</xsl:attribute>
        <div style="width:100%;position:relative;left:0;top:0;margin:0;border:0">
          	<xsl:choose>
            	<xsl:when test="$NoAJAX">
              <table CtxNum="{$ViewCounter}" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" name="{$fieldname}" DisplayName="{$displayname}" height="100%">
                <xsl:choose>
                  	<xsl:when test="$MasterVersion &gt;=4">
                    	<xsl:attribute name="style">width:100%;height:27px</xsl:attribute>
                  </xsl:when>
                  	<xsl:otherwise>
                    	<xsl:attribute name="style">width:100%</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$sortable='FALSE'">
                  	<xsl:attribute name="Sortable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@Filterable='FALSE'">
                  	<xsl:attribute name="Filterable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@FilterDisableMessage">
                  	<xsl:attribute name="FilterDisableMessage">
                    <xsl:value-of select="@FilterDisableMessage" />
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="not($sortable='FALSE') or not(@Filterable='FALSE')">
                  	<xsl:attribute name="onmouseover">
                    	<xsl:text disable-output-escaping="yes">OnMouseOverAdHocFilter(this, '</xsl:text>
                    <xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" />
                    	<xsl:text disable-output-escaping="yes">' , '', '')</xsl:text>
                  </xsl:attribute>
                  	<xsl:attribute name="SortFields"><xsl:value-of select="concat($RootFolderParam,$FieldSortParam,'SortField=',@Name,'&amp;SortDir=',$linkdir)"/></xsl:attribute>
                  	<xsl:attribute name="FieldType"><xsl:value-of select="@FieldType"/></xsl:attribute>
                  	<xsl:attribute name="ResultType"><xsl:value-of select="@ResultType"/></xsl:attribute>
                </xsl:if>
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:when>
            	<xsl:otherwise>
              <table style="width:100%;" Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
                 DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
                 height="100%" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" onmouseover="OnMouseOverFilter(this)">
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:otherwise>
          	</xsl:choose>
        </div>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="headerfield.Expires" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:choose>
      		<xsl:when test="$Filter='1'">
        <xsl:value-of select ="$Rows/@filter.render" disable-output-escaping ="yes"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="(@ImnHeader='TRUE') and ($PresenceEnabled='1')">
            <table cellpadding="0" cellspacing="0" dir="{$XmlDefinition/List/@Direction}">
              <tr>
                <td class="ms-imnImgTD">
                  <img border="0" valign="middle" height="12" width="12" altbase="{$idPresEnabled}" src="/_layouts/15/images/blank.gif?rev=40" onload="IMNRegisterHeader(event)" id="imnhdr{position()}"/>
                </td>
                <td nowrap="nowrap" class="ms-vh ms-imnTxtTD">
                  	<xsl:call-template name="FieldHeader.Expires">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </td>
              </tr>
            </table>
          </xsl:when>
          			<xsl:otherwise>
            			<xsl:choose>
              				<xsl:when test="$fieldtype='number'">
                <div align="right" class="ms-numHeader">
                  	<xsl:call-template name="FieldHeader.Expires">
                    	<xsl:with-param name="fieldname" select="$fieldname"/>
                    	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                    	<xsl:with-param name="displayname" select="$displayname"/>
                    	<xsl:with-param name="fieldtype" select="$fieldtype"/>
                  	</xsl:call-template>
                </div>
              </xsl:when>
              				<xsl:otherwise>
                				<xsl:call-template name="FieldHeader.Expires">
                  					<xsl:with-param name="fieldname" select="$fieldname"/>
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                  					<xsl:with-param name="displayname" select="$displayname"/>
                  					<xsl:with-param name="fieldtype" select="$fieldtype"/>
                				</xsl:call-template>
              </xsl:otherwise>
            			</xsl:choose>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldHeader.Expires" ddwrt:dvt_mode="header" ddwrt:ghost="hide">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname" />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:param name="thisNode" select="."/>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="not($sortable='FALSE')">
        		<xsl:variable name="sortfield">
          			<xsl:choose>
            			<xsl:when test="substring($fieldname, string-length($fieldname) - 5) = '(text)'">
              <xsl:value-of select="substring($fieldname, 1, string-length($fieldname) - 6)" />
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="$fieldname"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="linkdir">
          			<xsl:choose>
            			<xsl:when test="$dvt_sortfield = $sortfield and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
            			<xsl:otherwise>Asc</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="sortText">
          			<xsl:choose>
            			<xsl:when test="$linkdir='Desc'">&apos; + &apos;descending&apos; + &apos;</xsl:when>
            			<xsl:otherwise>&apos; + &apos;ascending&apos; + &apos;</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="jsescapeddisplayname">
          			<xsl:call-template name="fixQuotes">
            			<xsl:with-param name="string" select="$displayname"/>
          			</xsl:call-template>
        </xsl:variable>
        		<xsl:variable name="separator" select="' '" />
        		<xsl:variable name="connector" select="';'" />
        <a id="diidSort{$ViewCounter}{$fieldname}" class="ms-headerSortTitleLink" onfocus="OnFocusFilter(this)">
          		<xsl:attribute name="href">javascript: <xsl:if test="$NoAJAX">
              		<xsl:call-template name="GenFireServerEvent">
                		<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                		<xsl:with-param name="apos">'</xsl:with-param>
              		</xsl:call-template>
            </xsl:if>
          </xsl:attribute>
          		<xsl:attribute name="onclick">
            		<xsl:choose>
              			<xsl:when test="not($NoAJAX)">javascript:return OnClickFilter(this,event);</xsl:when>
              			<xsl:otherwise>javascript: <xsl:call-template name="GenFireServerEvent">
                  			<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                  			<xsl:with-param name="apos">'</xsl:with-param>
                			</xsl:call-template>; event.cancelBubble = true; return false;</xsl:otherwise>
            		</xsl:choose>
          </xsl:attribute>
          		<xsl:choose>
            		<xsl:when test="not($NoAJAX)">
              			<xsl:attribute name="SortingFields"><xsl:value-of select ="$RootFolderParam"/><xsl:value-of select ="$FieldSortParam"/>SortField=<xsl:value-of select="@Name"/>&amp;SortDir=<xsl:value-of select="$linkdir"/></xsl:attribute>
            </xsl:when>
            		<xsl:otherwise>
              			<xsl:attribute name="FilterString"><xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" /></xsl:attribute>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:choose>
            		<xsl:when test="$fieldtype = 'Attachments'">
              <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
            </xsl:when>
            		<xsl:otherwise>
              <xsl:value-of select="$fieldtitle"/>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:if test="$dvt_sortfield = $sortfield">
            		<xsl:choose>
              			<xsl:when test="$dvt_sortdir = 'ascending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortAsc}" src="{ddwrt:FieldSortImageUrl('Desc')}" />
              </xsl:when>
              			<xsl:when test="$dvt_sortdir = 'descending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortDesc}" src="{ddwrt:FieldSortImageUrl('Asc')}" />
              </xsl:when>
            		</xsl:choose>
          </xsl:if>
          <img src="/_layouts/15/images/blank.gif?rev=40" class="ms-hidden" border="0" width="1" height="1" alt=""/>
        </a>
        <img src="/_layouts/15/images/blank.gif?rev=40" alt="" border="0"/>
        		<xsl:choose>
          			<xsl:when test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
            <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
          </xsl:when>
          			<xsl:otherwise>
            <img src="/_layouts/15/images/blank.gif?rev=40" border="0" alt=""/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:when>
      		<xsl:when test="not(@Filterable='FALSE') and ($sortable='FALSE')">
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
          <img src="/_layouts/15/images/filter.gif?rev=40" border="0" alt="" />
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="($fieldtype='BusinessData') and not($XmlDefinition/List/@ExternalDataList='1')">
      <a style="padding-left:2px;padding-right:12px" onmouseover="" onclick="GoToLink(this);return false;"
        href="{$HttpVDir}/_layouts/15/BusinessDataSynchronizer.aspx?ListId={$List}&amp;ColumnName={$fieldname}">
        <img border="0" src="/_layouts/15/images/bdupdate.gif?rev=40" alt="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}" title="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}"/>
      </a>
    </xsl:if>
  </xsl:template>
	<xsl:template match="View" mode="RenderView" ddwrt:ghost="hide">
    	<xsl:variable name="ViewStyleID">
      <xsl:value-of select="ViewStyle/@ID"/>
    </xsl:variable>
    	<xsl:variable name="HasExtraColumn" select="$TabularView='1' and $MasterVersion>=4 and ($ViewStyleID = '' or $ViewStyleID = '17')"/>
    	<xsl:if test="Aggregations[not(@Value='Off')]/FieldRef">
      <tr>
        <xsl:if test="$HasExtraColumn">
          <td/>
        </xsl:if>
        <xsl:if test="$InlineEdit">
          <td width="1%"/>
        </xsl:if >
        <xsl:apply-templates mode="aggregate" select="ViewFields/FieldRef[not(@Explicit='TRUE')]">
          	<xsl:with-param name="Rows" select="$AllRows"/>
          	<xsl:with-param name="GroupLevel" select="0"/>
        </xsl:apply-templates>
      </tr>
    </xsl:if>
    	<xsl:variable name="Fields" select="ViewFields/FieldRef[not(@Explicit='TRUE')]"/>
    	<xsl:variable name="Groups" select="Query/GroupBy/FieldRef"/>
    	<xsl:variable name="Collapse" select="Query/GroupBy[@Collapse='TRUE']"/>
    	<xsl:variable name="GroupCount" select="count($Groups)"/>
    	<xsl:choose>
      		<xsl:when test="$ClientRender='1'">
        <script id="script{$ContainerId}"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:for-each select="$AllRows">
          			<xsl:variable name="thisNode" select="."/>
          			<xsl:if test="$GroupCount &gt; 0">
            			<xsl:call-template name="GroupTemplate">
              				<xsl:with-param name="Groups" select="$Groups"/>
              				<xsl:with-param name="Collapse" select="$Collapse"/>
              				<xsl:with-param name="HasExtraColumn" select="$HasExtraColumn"/>
            			</xsl:call-template>
          </xsl:if>
          			<xsl:if test="not(not($NoAJAX) and not($InlineEdit) and $Collapse and $GroupCount &gt; 0)">
            <xsl:apply-templates mode="Item" select=".">
              	<xsl:with-param name="Fields" select="$Fields"/>
              	<xsl:with-param name="Collapse" select="$Collapse"/>
              	<xsl:with-param name="Position" select="position()"/>
              	<xsl:with-param name="Last" select="last()"/>
            </xsl:apply-templates>
          </xsl:if>
        </xsl:for-each>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="$InlineEdit and not($IsDocLib) and $ListRight_AddListItems = '1'">
      		<xsl:call-template name="rowinsert">
        		<xsl:with-param name="Fields" select="$Fields"/>
      		</xsl:call-template>
    </xsl:if>
  </xsl:template>
	<xsl:template mode="Item" match="Row[../../@ViewStyleID='12' or ../../@ViewStyleID='13' or ../../@ViewStyleID='18' or ../../@ViewStyleID='19']" ddwrt:ghost="hide">
    	<xsl:param name="Fields" select="."/>
    	<xsl:param name="Collapse" select="."/>
    	<xsl:param name="Position" select="1"/>
    	<xsl:param name="Last" select="1"/>
    	<xsl:variable name="thisNode" select="."/>
    	<xsl:variable name="ShowLabels">
      		<xsl:choose>
        		<xsl:when test="../../@ViewStyleID='13' or ../../@ViewStyleID='18'">1</xsl:when>
        		<xsl:otherwise>0</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="ID">
      		<xsl:call-template name="ResolveId"><xsl:with-param name="thisNode" select ="."/></xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="FSObjType">
      		<xsl:choose>
        		<xsl:when test="$EntityName != ''">0</xsl:when>
        		<xsl:otherwise><xsl:value-of select="./@FSObjType"/></xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="labelWidth">
      		<xsl:choose>
        		<xsl:when test='$ShowLabels=1'>20%</xsl:when>
        		<xsl:otherwise>20px</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="bodyWidth">
      		<xsl:choose>
        		<xsl:when test='$ShowLabels=1'>80%</xsl:when>
        		<xsl:otherwise></xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    <td valign="top" width="50%" class="ms-stylebox">
      <table border="0" width="100%">
        <xsl:for-each select="$Fields">
          <tr>
            <td class="ms-stylelabel">
              	<xsl:attribute name="width"><xsl:value-of select="$labelWidth"/></xsl:attribute>
              	<xsl:if test='$ShowLabels=1'>
                <xsl:value-of select="@DisplayName"/>
              </xsl:if>
            </td>
            <td class="ms-stylebody">
              	<xsl:attribute name="width"><xsl:value-of select="$bodyWidth"/></xsl:attribute>
              <xsl:apply-templates select="." mode="PrintFieldWithDisplayFormLink">
                <xsl:with-param name="thisNode" select="$thisNode"/>
              </xsl:apply-templates>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </td>
    	<xsl:call-template name="NewTRJumbo">
      		<xsl:with-param name="Position" select="$Position"/>
      		<xsl:with-param name="Collapse" select="$Collapse"/>
    	</xsl:call-template>
  </xsl:template>
	<xsl:template match="FieldRef[@Name='LinkTitle']" name="LinkTitleNoMenu.LinkTitle" mode="Computed_LinkTitle_body" ddwrt:tag="a" ddwrt:dvt_mode="body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    	<xsl:param name="ShowAccessibleIcon" select="0"/>
    	<xsl:param name="folderUrlAdditionalQueryString" select="''"/>
    	<xsl:variable name="ID">
      		<xsl:call-template name="ResolveId">
        		<xsl:with-param name="thisNode" select ="$thisNode"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$thisNode/@FSObjType='1'">
        		<xsl:call-template name="LinkFilenameNoMenu">
          			<xsl:with-param name="thisNode" select="$thisNode"/>
          			<xsl:with-param name="folderUrlAdditionalQueryString" select="$folderUrlAdditionalQueryString"/>
        		</xsl:call-template>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
              		<xsl:when test="$XmlDefinition/List/@TemplateType != 301">
                  <a onfocus="OnLink(this)" href="{$FORM_DISPLAY}&amp;ID={$ID}&amp;ContentTypeID={$thisNode/@ContentTypeId}" onclick="EditLink2(this,{$ViewCounter});return false;" target="_self">
                      	<xsl:call-template name="LinkTitleValue.LinkTitle">
                        	<xsl:with-param name="thisNode" select="$thisNode"/>
                        	<xsl:with-param name="ShowAccessibleIcon" select="$ShowAccessibleIcon"/>
                     	</xsl:call-template>
                  </a>
              </xsl:when>
              		<xsl:otherwise>
                    <a onfocus="OnLink(this)" href="{$FORM_DISPLAY}&amp;ID={$ID}" onclick="GoToLink(this);return false;" target="_self">
                      	<xsl:call-template name="LinkTitleValue.LinkTitle">
                        	<xsl:with-param name="thisNode" select="$thisNode"/>
                        	<xsl:with-param name="ShowAccessibleIcon" select="$ShowAccessibleIcon"/>
                     	</xsl:call-template>
                  </a>
              </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="$thisNode/@Created_x0020_Date.ifnew='1'">
          			<xsl:call-template name="NewGif.LinkTitle">
            			<xsl:with-param name="thisNode" select="$thisNode"/>
          			</xsl:call-template>
        </xsl:if>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="LinkTitleValue.LinkTitle" ddwrt:dvt_mode="body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    	<xsl:param name="ShowAccessibleIcon" select="0"/>
    	<xsl:variable name="titlevalue" select="$thisNode/@Title"/>
    	<xsl:choose>
      		<xsl:when test="$titlevalue=''">
        <xsl:value-of select="$Rows/@resource.wss.NoTitle"/>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$HasTitleField">
            <xsl:value-of disable-output-escaping="yes" select="$titlevalue" />
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$titlevalue" />
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:choose>
      		<xsl:when test="$ShowAccessibleIcon">
        <img src="/_layouts/15/images/blank.gif?rev=40" class="ms-hidden" border="0" width="1" height="1" alt="{$idPresEnabled}" />
      </xsl:when>
      		<xsl:otherwise></xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="NewGif.LinkTitle" ddwrt:dvt_mode="body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    <img src="/_layouts/15/{$LCID}/images/new.gif" alt="{$NewGifAltString}" title="{$NewGifAltString}" class="ms-newgif" />
  </xsl:template>
	<xsl:template name="FieldRef_DateTime_body.Modified" ddwrt:dvt_mode="body" match ="FieldRef[@Name='Modified']" mode="DateTime_body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    	<xsl:choose>
      		<xsl:when test="$FreeForm">
        		<xsl:call-template name="FieldRef_ValueOf.Modified">
          			<xsl:with-param name="thisNode" select="$thisNode"/>
        		</xsl:call-template>
      </xsl:when>
      		<xsl:otherwise>
        <nobr>
          		<xsl:call-template name="FieldRef_ValueOf.Modified">
            		<xsl:with-param name="thisNode" select="$thisNode"/>
          		</xsl:call-template>
        </nobr>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldRef_ValueOf.Modified" ddwrt:dvt_mode="body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    <xsl:value-of select="$thisNode/@*[name()=current()/@Name]"/>
  </xsl:template>
	<xsl:template name="FieldRef_Note_body.Body" ddwrt:dvt_mode="body" match="FieldRef[@Name='Body']" mode="Note_body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    <div dir="{@Direction}" class="ms-rtestate-field">
      <xsl:value-of select="$thisNode/@*[name()=current()/@Name]" disable-output-escaping="yes"/>
    </div>
  </xsl:template>
	<xsl:template name="FieldRef_DateTime_body.Expires" ddwrt:dvt_mode="body" match ="FieldRef[@Name='Expires']" mode="DateTime_body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    	<xsl:choose>
      		<xsl:when test="$FreeForm">
        		<xsl:call-template name="FieldRef_ValueOf.Expires">
          			<xsl:with-param name="thisNode" select="$thisNode"/>
        		</xsl:call-template>
      </xsl:when>
      		<xsl:otherwise>
        <nobr>
          		<xsl:call-template name="FieldRef_ValueOf.Expires">
            		<xsl:with-param name="thisNode" select="$thisNode"/>
          		</xsl:call-template>
        </nobr>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	<xsl:template name="FieldRef_ValueOf.Expires" ddwrt:dvt_mode="body" ddwrt:ghost="hide">
    	<xsl:param name="thisNode" select="."/>
    <xsl:value-of select="$thisNode/@*[name()=current()/@Name]"/>
  </xsl:template>
	<xsl:template name="NewTRJumbo" ddwrt:ghost="" xmlns:ddwrt2="urn:frontpage:internal">
    	<xsl:param name="Position" select="1"/>
    	<xsl:param name="Collapse" select="."/>
    	<xsl:choose>
      		<xsl:when test="$Position mod 2 = 0">
        		<xsl:text disable-output-escaping="yes">&lt;/tr&gt;</xsl:text>
        		<xsl:call-template name="NewTR">
          			<xsl:with-param name="Collapse" select="$Collapse"/>
          			<xsl:with-param name="EmptyLine" select="1"/>
        		</xsl:call-template>
        		<xsl:text disable-output-escaping="yes">&lt;td&gt;&lt;/td&gt;&lt;/tr&gt;</xsl:text>
        		<xsl:call-template name="NewTR">
          			<xsl:with-param name="Collapse" select="$Collapse"/>
        		</xsl:call-template>
      </xsl:when>
      		<xsl:otherwise>
        <td width="1.5%">
          	<xsl:text ddwrt:nbsp-preserve="yes" disable-output-escaping="yes">&amp;nbsp;</xsl:text>
        </td>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template><xsl:template name="NewTR" ddwrt:ghost="hide">
    	<xsl:param name="Collapse" select="."/>
    	<xsl:param name="EmptyLine" select="0"/>
    	<xsl:text disable-output-escaping="yes">&lt;tr</xsl:text>
    	<xsl:if test="$Collapse">
      		<xsl:text disable-output-escaping="yes"> style=&quot;display:none&quot;</xsl:text>
    </xsl:if>
    	<xsl:if test="$EmptyLine">
      		<xsl:text disable-output-escaping ="yes"> style=&quot;font-size: 6px&quot;</xsl:text>
    </xsl:if>
    	<xsl:text disable-output-escaping ="yes">&gt;</xsl:text>
  </xsl:template><xsl:template name="pagingButtons" ddwrt:ghost="hide">
    	<xsl:choose>
      		<xsl:when test="$XmlDefinition/List/@TemplateType = 106 and $XmlDefinition/@RecurrenceRowset='TRUE'">
        		<xsl:if test="$dvt_nextpagedata or $dvt_prevpagedata">
          			<xsl:call-template name="CalendarExpandedRecurrenceFooter"/>
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
      			<xsl:if test="$XmlDefinition/RowLimit[@Paged='TRUE']">
        			<xsl:call-template name="CommandFooter">
          				<xsl:with-param name="FirstRow" select="$FirstRow" />
          				<xsl:with-param name="LastRow" select="$LastRow" />
          				<xsl:with-param name="dvt_RowCount" select="$dvt_RowCount" />
        			</xsl:call-template>
      </xsl:if>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template><xsl:template name="CommandFooter" ddwrt:ghost="hide">
    	<xsl:param name="FirstRow" select="1"/>
    	<xsl:param name="LastRow" select="1"/>
    	<xsl:param name="dvt_RowCount" select="1"/>
    	<xsl:if test="$FirstRow &gt; 1 or $dvt_nextpagedata">
      		<xsl:call-template name="Navigation">
	    		<xsl:with-param name="FirstRow" select="$FirstRow" />
        		<xsl:with-param name="LastRow" select="$LastRow" />
        		<xsl:with-param name="dvt_RowCount" select="$dvt_RowCount" />
      		</xsl:call-template>
    </xsl:if>
  </xsl:template><xsl:template name="Navigation" ddwrt:ghost="hide">
    	<xsl:param name="FirstRow" select="1"/>
    	<xsl:param name="LastRow" select="1"/>
    	<xsl:param name="dvt_RowCount" select="1"/>
    	<xsl:variable name="LastRowValue" select="$LastRow" />
    	<xsl:variable name="NextRow">
      <xsl:value-of select="$LastRowValue + 1"/>
    </xsl:variable>
    	<xsl:variable name="RealRowLimit">
      		<xsl:choose>
        		<xsl:when test="$XmlDefinition/Query/GroupBy[@Collapse='TRUE']/@GroupLimit">
          <xsl:value-of select ="$XmlDefinition/Query/GroupBy[@Collapse='TRUE']/@GroupLimit"/>
        </xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select = "$XmlDefinition/RowLimit"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
		<xsl:variable name="PrevHref">
        <xsl:value-of select="$PagePath"/>?<xsl:value-of select="$dvt_prevpagedata"/><xsl:value-of select="$ShowWebPart"/>&amp;PageFirstRow=<xsl:value-of select="$FirstRow - $RealRowLimit"/>&amp;<xsl:value-of select='$FieldSortParam'/><xsl:value-of select='$SortQueryString'/>&amp;View=<xsl:value-of select="$View"/>
	</xsl:variable>                                                
		<xsl:variable name="NextHref">
        <xsl:value-of select="$PagePath"/>?<xsl:value-of select="$dvt_nextpagedata"/><xsl:value-of select="$ShowWebPart"/>&amp;PageFirstRow=<xsl:value-of select="$NextRow"/>&amp;<xsl:value-of select='$FieldSortParam'/><xsl:value-of select='$SortQueryString'/>&amp;View=<xsl:value-of select="$View"/>
	</xsl:variable>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="ms-bottompaging">
      <tr>
        <td class="ms-bottompagingline1">
          <img src="/_layouts/15/images/blank.gif?rev=40" width="1" height="1" alt=""/>
        </td>
      </tr>
      <tr>
        <td class="ms-bottompagingline2">
          <img src="/_layouts/15/images/blank.gif?rev=40" width="1" height="1" alt=""/>
        </td>
      </tr>
      <tr>
        <td class="ms-vb" id="bottomPagingCell{$WPQ}">
          	<xsl:if test="not($GroupingRender)">
            	<xsl:attribute name="align">center</xsl:attribute>
          </xsl:if>
          <table>
            <tr>
              	<xsl:if test="$dvt_firstrow &gt; 1">
                <td>
                  <a>
                    <xsl:choose>
                      	<xsl:when test="$dvt_RowCount = 0">
                        	<xsl:choose>
                          		<xsl:when test="not($NoAJAX)">
                            		<xsl:attribute name="onclick">javascript:RefreshPageTo(event, "<xsl:value-of select="$PagePath"/>?<xsl:value-of select="$ShowWebPart"/>\u0026<xsl:value-of select='$FieldSortParam'/><xsl:value-of select='$SortQueryString'/>\u0026View=<xsl:value-of select="$View"/>");javascript:return false;</xsl:attribute>
                            		<xsl:attribute name="href">javascript:</xsl:attribute>
                          </xsl:when>
                          		<xsl:otherwise>
                            		<xsl:attribute name="href">
                              javascript: <xsl:call-template name="GenFireServerEvent">
                                			<xsl:with-param name="param" select="'dvt_firstrow={1};dvt_startposition={}'"/>
                              			</xsl:call-template>
                            </xsl:attribute>
                          </xsl:otherwise>
                        	</xsl:choose>
                        <img src="/_layouts/15/{$LCID}/images/prev.gif" border="0" alt="{$Rows/@idRewind}" />
                        <img src="/_layouts/15/{$LCID}/images/prev.gif" border="0" alt="{$Rows/@idRewind}" />
                      </xsl:when>
                      	<xsl:otherwise>
                        	<xsl:choose>
                          		<xsl:when test="not($NoAJAX)">                          
                            		<xsl:attribute name="onclick">javascript:RefreshPageTo(event, "<xsl:value-of select="$PrevHref"/>");javascript:return false;</xsl:attribute>
                            		<xsl:attribute name="href">javascript:</xsl:attribute>
                          </xsl:when>
                          		<xsl:otherwise>
                            		<xsl:attribute name="href">
                              javascript: <xsl:call-template name="GenFireServerEvent">
                                			<xsl:with-param name="param" select="concat('dvt_firstrow={',$FirstRow - $XmlDefinition/RowLimit,'};dvt_startposition={',$dvt_prevpagedata,'}')"/>
                              			</xsl:call-template>
                            </xsl:attribute>
                          </xsl:otherwise>
                        	</xsl:choose>
                        <img src="/_layouts/15/{$LCID}/images/prev.gif" border="0" alt="{$Rows/@idPrevious}" />
                      </xsl:otherwise>
                    </xsl:choose>
                  </a>
				</td>
              </xsl:if>
              	<xsl:if test="$FirstRow &lt;= $LastRowValue">
                  <td class="ms-paging">
                       <xsl:value-of select="$FirstRow" /> - <xsl:value-of select="$LastRowValue" />				  
                  </td>
              </xsl:if>
              	<xsl:if test="$LastRowValue &lt; $dvt_RowCount or string-length($dvt_nextpagedata)!=0">
                <td>
                  <a>
                    <xsl:choose>
                      	<xsl:when test="not($NoAJAX)">
                        	<xsl:attribute name="onclick">javascript:RefreshPageTo(event, "<xsl:value-of select='$NextHref'/>");javascript:return false;</xsl:attribute>
                        	<xsl:attribute name="href">javascript:</xsl:attribute>
                      </xsl:when>
                      	<xsl:otherwise>
                        	<xsl:attribute name="href">javascript: <xsl:call-template name="GenFireServerEvent">
                            	<xsl:with-param name="param" select="concat('dvt_firstrow={',$NextRow,'};dvt_startposition={',$dvt_nextpagedata,'}')"/>
                          		</xsl:call-template>
                        </xsl:attribute>
                      </xsl:otherwise>
                    </xsl:choose>
                    <img src="/_layouts/15/{$LCID}/images/next.gif" border="0" alt="{$Rows/@tb_nextpage}" />
                  </a>
                </td>
              </xsl:if>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td class="ms-bottompagingline3">
          <img src="/_layouts/15/images/blank.gif?rev=40" width="1" height="1" alt=""/>
        </td>
      </tr>
    </table>
    	<xsl:if test="not($GroupingRender)">
      		<xsl:variable name="scriptbody19">
      var topPagingCell = document.getElementById("topPagingCell<xsl:value-of select='$WPQ'/>");
      var bottomPagingCell = document.getElementById("bottomPagingCell<xsl:value-of select='$WPQ'/>");
      if (topPagingCell != null &amp;&amp; bottomPagingCell != null)
      {
      topPagingCell.innerHTML = bottomPagingCell.innerHTML;
      }
      </xsl:variable>
      <xsl:value-of select="pcm:RegisterScriptBlock(concat('block19', $WPQ), string($scriptbody19))"/>
    </xsl:if>
  </xsl:template><xsl:template name="Freeform" ddwrt:ghost="hide">
    	<xsl:param name="AddNewText"/>
    	<xsl:param name="ID"/>
    	<xsl:variable name="Url">
      		<xsl:choose>
        		<xsl:when test="List/@TemplateType='119'"><xsl:value-of select="$HttpVDir"/>/_layouts/15/CreateWebPage.aspx?List=<xsl:value-of select="$List"/>&amp;RootFolder=<xsl:value-of select="$XmlDefinition/List/@RootFolder"/></xsl:when>
        		<xsl:when test="$IsDocLib"><xsl:value-of select="$HttpVDir"/>/_layouts/15/Upload.aspx?List=<xsl:value-of select="$List"/>&amp;RootFolder=<xsl:value-of select="$XmlDefinition/List/@RootFolder"/></xsl:when>
        		<xsl:otherwise><xsl:value-of select="$ENCODED_FORM_NEW"/></xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="HeroStyle">
      		<xsl:choose>
        		<xsl:when test="Toolbar[@Type='Standard']">display:none</xsl:when>
        		<xsl:otherwise></xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:if test="$ListRight_AddListItems = '1' and (not($InlineEdit) or $IsDocLib)">
      <table id="Hero-{$WPQ}" width="100%" cellpadding="0" cellspacing="0" border="0" style="{$HeroStyle}">
        <tr>
          <td colspan="2" class="ms-partline">
            <img src="/_layouts/15/images/blank.gif?rev=40" width="1" height="1" alt="" />
          </td>          
        </tr>
        <tr>
          <td class="ms-addnew" style="padding-bottom: 3px">
          <span style="height:10px;width:10px;position:relative;display:inline-block;overflow:hidden;" class="s4-clust"><img src="/_layouts/15/images/fgimg.png?rev=40" alt="" style="left:-0px !important;top:-32px !important;position:absolute;"  /></span>
          	<xsl:text disable-output-escaping="yes" ddwrt:nbsp-preserve="yes">&amp;nbsp;</xsl:text>
          	<xsl:choose>
            	<xsl:when test="List/@TemplateType = '115'">
              <a class="ms-addnew" id="{$ID}-{$WPQ}"
                 href="{$Url}" data-viewCtr="{$ViewCounter}" 
                 onclick="NewItem2(event, &quot;{$Url}&quot;); return false;"
                 target="_self">
                <xsl:value-of select="$AddNewText" />
              </a>
            </xsl:when>
            	<xsl:otherwise>
              <a class="ms-addnew" id="{$ID}"
                 href="{$Url}" data-viewCtr="{$ViewCounter}" 
                 onclick="NewItem2(event, &quot;{$Url}&quot;); return false;"
                 target="_self">
                <xsl:value-of select="$AddNewText" />
              </a>
            </xsl:otherwise>
          	</xsl:choose>
          </td>
        </tr>
        <tr>
          <td>
            <img src="/_layouts/15/images/blank.gif?rev=40" width="1" height="5" alt="" />
          </td>
        </tr>
      </table>
      		<xsl:choose>
        		<xsl:when test="Toolbar[@Type='Standard']">
          			<xsl:variable name="scriptbody15">
            if (typeof(heroButtonWebPart<xsl:value-of select="$WPQ"/>) != "undefined")
            {
                <xsl:value-of select="concat('  var eleHero = document.getElementById(&quot;Hero-', $WPQ, '&quot;);')"/>
                if (eleHero != null)
                    eleHero.style.display = "";
            }
          </xsl:variable>
          <xsl:value-of select="pcm:RegisterScriptBlock(concat('block15',$WPQ), string($scriptbody15))"/>
        </xsl:when>
        		<xsl:otherwise>
        </xsl:otherwise>
      		</xsl:choose>
      		<xsl:if test="List/@TemplateType = '115'">
         		<xsl:variable name="scriptbody16">
            if (typeof(DefaultNewButtonWebPart<xsl:value-of select="$WPQ"/>) != "undefined")
            {
                <xsl:value-of select="concat('  var eleLink = document.getElementById(&quot;', $ID, '-', $WPQ, '&quot;);')"/>
                if (eleLink != null)
                {
                    DefaultNewButtonWebPart<xsl:value-of select="$WPQ"/>(eleLink);
                }
            }
          </xsl:variable>
                  <
          <xsl:value-of select="pcm:RegisterScriptBlock(concat('block16',$WPQ), string($scriptbody16))"/>                  
      </xsl:if>
    </xsl:if>
  </xsl:template></xsl:stylesheet></xsl></WebPartPages:XsltListViewWebPart>

</asp:Content>
