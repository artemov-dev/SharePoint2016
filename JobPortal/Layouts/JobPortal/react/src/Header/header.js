import React from 'react'
import ReactDOM from 'react-dom'
import { HeadMenu } from './HeadMenu'
import { IconButton, Image, initializeIcons, Label, loadTheme, Panel, PanelType, Stack, Text } from 'office-ui-fabric-react';
import { EditWrapper } from '../EditWrapper';
import { Logo } from './Logo';

loadTheme({
	palette: {
		themePrimary: '#ff9900',
		themeLighterAlt: '#fffbf5',
		themeLighter: '#ffefd6',
		themeLight: '#ffe0b3',
		themeTertiary: '#ffc266',
		themeSecondary: '#ffa51f',
		themeDarkAlt: '#e68a00',
		themeDark: '#c27400',
		themeDarker: '#8f5600',
		neutralLighterAlt: '#f1f1f1',
		neutralLighter: '#ededed',
		neutralLight: '#e3e3e3',
		neutralQuaternaryAlt: '#d3d3d3',
		neutralQuaternary: '#cacaca',
		neutralTertiaryAlt: '#c2c2c2',
		neutralTertiary: '#a19f9d',
		neutralSecondary: '#605e5c',
		neutralPrimaryAlt: '#3b3a39',
		neutralPrimary: '#323130',
		neutralDark: '#201f1e',
		black: '#000000',
		white: '#f7f7f7',
	},
});

initializeIcons('/_layouts/15/JobPortal/react/public/fluenticons/', { disableWarnings: true });



function Header() {

	const [clickedLogo, setclickedLogo] = React.useState(false)
	const [clickedSubmit, setclickedSubmit] = React.useState(false)
	const [ImageSearch, setImageSearch] = React.useState(false)

	const SubmitEditPanel = () => {
		return (
			<Panel
				headerText="Submit Panel"
				isOpen={clickedSubmit}
				onDismiss={() => { setclickedSubmit(!clickedSubmit) }}
				// You MUST provide this prop! Otherwise screen readers will just say "button" with no label.
				closeButtonAriaLabel="Close"
			>
				<p>Content Submit.</p>
			</Panel>
		)
	}

	return (
		<div className="ms-dialogHidden">
			<header>
				{/* <!-- header container start here--> */}
				<div className="container">
					<div className="row">
						<div className="col-sm-3 col-md-3 col-xs-12">
							{/* <!-- logo start here--> */}
							<Logo />
							{/* <!-- logo end here--> */}
						</div>
						<div className="col-sm-3 col-md-3 col-xs-12 visible-xs paddleft">
							{/* <!-- button-login start here --> */}
							<EditWrapper >
								<div className="button-login pull-right">
									<button type="button" className="btn btn-primary btn-lg" onClick={() => console.log('Submit Button')}>Submit Job</button>
								</div>
							</EditWrapper>
							{/* <!-- button-login end here --> */}
						</div>
						<HeadMenu />
						<div className="col-sm-3 col-md-3 col-xs-12 hidden-xs">
							{/* <!-- button-login start here --> */}
							<EditWrapper>
								<div className="button-login pull-right">
									<button type="button" className="btn btn-primary btn-lg" onClick={() => console.log('Submit Button')}>Submit Job</button>
								</div>
							</EditWrapper>
							{/* <!-- button-login end here --> */}
						</div>
					</div>
				</div>
				{/* <!-- header container end here --> */}

			</header>


		</div>
	)
}

ExecuteOrDelayUntilScriptLoaded(() => {

	ReactDOM.render(
		<Header />,
		document.getElementById("header")
	)

}, "sp.js");

