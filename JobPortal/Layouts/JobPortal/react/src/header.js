import React from 'react'
import ReactDOM, { render } from 'react-dom'
import { SPServices } from './ArtDevServices'
import { HeadMenu } from './Header/HeadMenu'


function Header() {
	const [EditMode, setEditMode] = React.useState(false)
	const [MouseOver, setMouseOver] = React.useState(false)

	React.useEffect(() => {
		SPServices.isInEditMode().then(data => setEditMode(data))
	}, [])


	const BorderShadow = {
		border: '2px solid rgb(171, 171, 171)',
	}



	return (
		<header className="ms-dialogHidden" style={EditMode && MouseOver ? BorderShadow : null} onMouseLeave={() => setMouseOver(false)} onMouseOver={() => setMouseOver(true)}>
			{/* <!-- header container start here--> */}

			{EditMode && MouseOver &&
				<i className="ms-Icon ms-Icon--Edit"
					style={{ float: 'right', marginTop: '2px', marginRight: '2px' }}
					onClick={() => { SPServices.OpenModalDialog('/Lists/ArtDevHeaderMenu/ForHeader.aspx') }} >
				</i>
			}

			<div className="container">
				<div className="row">
					<div className="col-sm-3 col-md-3 col-xs-12">
						{/* <!-- logo start here--> */}
						<div id="logo">
							<a href="/">
								<img className="img-responsive logochange" alt="logo" title="logo" src="/_layouts/15/JobPortal/images/logo.png" />
							</a>
						</div>
						{/* <!-- logo end here--> */}
					</div>
					<div className="col-sm-3 col-md-3 col-xs-12 visible-xs paddleft">
						{/* <!-- button-login start here --> */}
						<div className="button-login pull-right">
							<button type="button" className="btn btn-primary btn-lg" onClick={() => console.log('Submit Button')}>Submit Job</button>
						</div>
						{/* <!-- button-login end here --> */}
					</div>
					<HeadMenu />
					<div className="col-sm-3 col-md-3 col-xs-12 hidden-xs">
						{/* <!-- button-login start here --> */}
						<div className="button-login pull-right">
							<button type="button" className="btn btn-primary btn-lg" onClick={() => console.log('Submit Button')}>Submit Job</button>
						</div>
						{/* <!-- button-login end here --> */}
					</div>
				</div>
			</div>
			{/* <!-- header container end here --> */}

		</header>



	)
}

ExecuteOrDelayUntilScriptLoaded(() => {

	ReactDOM.render(
		<Header />,
		document.getElementById("header")
	)

}, "sp.js");

