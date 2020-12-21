import { CommandBarBase, divProperties } from 'office-ui-fabric-react'
import React from 'react'
import ReactDOM from 'react-dom'
import {CommandBarSplitDisabledExample} from './commandBar/commandBar.tsx'
import {PivotLargeExample} from './pivot.tsx'
import {VerticalStackWrapExample} from './news/news.tsx'

SP.SOD.executeFunc("clienttemplates.js", "SPClientTemplates", function() {

Type.registerNamespace('CSR')
var CSR = CSR || {}
CSR.Templates = CSR.Templates || {};
CSR.Functions = CSR.Functions || {};
CSR.Variables = CSR.Variables || {}; 
CSR.Variables.Items = CSR.Variables.Items || []; 


CSR.ListTemplateType = 10000;
CSR.Templates = {    
    Header: function (ctx) {
        
        //var newItemFormUrl = ctx.newFormUrl;
        //var newItemLink = "<a onclick='NewItem2(event, '" + newItemFormUrl + "'); return false;' href='" + newItemFormUrl + " target='_self' data-viewctr='0'>New Item</a>";
        //return "<div style='border:solid 1px #aaa; padding:4px; background-color: #ddd;' >" + newItemLink + "</div>";
        CSR.Variables.newFormUrl = ctx.newFormUrl;
        
          return '<div id="header-news"></div>'
          
    },
    Body: function (ctx) {
        return ('<div id="body-news">'+RenderBodyTemplate(ctx)+'</div>')
    },
    Item: function (ctx) {
        // create item style
        //var itemStyle = " width:600px;margin:12px;";
        //var titleStyle = "background-color:black;color:white;padding:2px; padding-left:12px;font-size:1.25em;border-top-left-radius:16px";
        //var bodyStyle = "border:black 1px solid;background-color:#ddd;color:#333;padding:4px;border-bottom-right-radius:16px";

        // create and return HTML for each item
        //return "<div style='" + itemStyle + "'>" +
        //    "<div style='" + titleStyle + "'>" + ctx.CurrentItem.Title + "</div>" +
        //    "<div style='" + bodyStyle + "'>" + ctx.CurrentItem.Body + "</div>" +
        //    "</div>";
        var news = {
            Title: ctx.CurrentItem.Title,
            Body: ctx.CurrentItem.Body
        }
        CSR.Variables.Items.push(news)      
        return '<div id="item-news"></div>'
    },
    Footer: function (ctx) { return "<div style='height:4px;background-color:black' />"; }    
}
CSR.OnPostRender = function (ctx) {
    ReactDOM.render(
        <CommandBarSplitDisabledExample />,
        document.getElementById('header-news')
    )
    console.log(CSR.Variables.Items)
    ReactDOM.render(
        <VerticalStackWrapExample />,
        document.getElementById('body-news')
    )
   

} 



CSR.Functions.RegisterTemplate = function () {
    // register our object, which contains our templates
    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(CSR);
};
CSR.Functions.MdsRegisterTemplate = function () {
    // register our custom template
    CSR.Functions.RegisterTemplate();

    // and make sure our custom view fires each time MDS performs
    // a page transition
    var thisUrl = _spPageContextInfo.siteServerRelativeUrl + "SiteAssets/News.csr.js";
    RegisterModuleInit(thisUrl, CSR.Functions.RegisterTemplate)
};
if (typeof _spPageContextInfo != "undefined" && _spPageContextInfo != null) {
    // its an MDS page refresh
    CSR.Functions.MdsRegisterTemplate()
} else {
    // normal page load
    CSR.Functions.RegisterTemplate()
}



})


