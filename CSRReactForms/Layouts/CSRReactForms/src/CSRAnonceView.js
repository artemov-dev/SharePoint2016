import React from 'react'
import ReactDOM from 'react-dom'
import {CommandBarNews} from './commandBar/CommandBarNews.tsx'
import { HorizontalStackConfigureExample } from './commandBar/wrap.tsx';
import CSR from './CSR'
import { initializeIcons } from 'office-ui-fabric-react';
import {ArtDevServices} from './ArtDevServices';
initializeIcons('/_layouts/15/CSRReactForms/public/fluenticons/', { disableWarnings: true });

/* fetch('http://portal.contoso.com/_api/web/allProperties')
    .then(response => response.text())
    .then(xml => (new window.DOMParser()).parseFromString(xml, "application/xml"))
    .then(result => console.log(result.getElementsByTagName('d:DEV').length)) */


SP.SOD.executeFunc("clienttemplates.js", "SPClientTemplates", function() {

CSR.ListTemplateType = 10000;


CSR.OnPreRender = function (ctx) {   }

 CSR.Templates = {    
        Header: function (ctx) {             
        return '<div id="header-news"></div>'          
        },

        Body: function (ctx) { 
        return ('<div id="body-news">'+RenderBodyTemplate(ctx)+'</div>')
        },

        Item: function (ctx) {
        CSR.Variables.Items.push(ctx.CurrentItem)    
        return '<div id="item-news"></div>'        
        }
        ,   
        Fields: { 
            "Title": {            
                EditForm: CSR.NewOrEditControl,
                NewForm: CSR.NewOrEditControl
            } 
        },

        Footer: function (ctx) { return ""; }    
    } 
CSR.OnPostRender = function (ctx) {      
    CSR = CSR.Functions.AddField(ctx) 
    CSR = CSR.Functions.CreateTab(ctx)
    


     ReactDOM.render(        
        <HorizontalStackConfigureExample />,
        document.getElementById('body-news')
    )
    
    ReactDOM.render(
        <CommandBarNews LinkNewForm = {ctx.newFormUrl}/>,
        document.getElementById('header-news')
    )
} 
SPClientTemplates.TemplateManager.RegisterTemplateOverrides(CSR);

})



