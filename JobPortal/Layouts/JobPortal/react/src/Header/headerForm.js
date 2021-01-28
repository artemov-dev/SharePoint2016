import * as React from 'react'
import ReactDOM from 'react-dom'
import { HeadEditPanel } from './HeadEditPanel'
import { initializeIcons } from 'office-ui-fabric-react';
initializeIcons('/_layouts/15/JobPortal/react/public/fluenticons/', { disableWarnings: true });


    ReactDOM.render(
        <HeadEditPanel />,
        document.getElementById("headerForm")
    )
    

