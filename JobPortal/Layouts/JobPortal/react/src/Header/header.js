import React from 'react'
import ReactDOM from 'react-dom'
import { SPServices } from '../ArtDevServices'
import { HeadMenu } from './HeadMenu'
import classes from './Header.module'


function Header() {
	const [EditMode, setEditMode] = React.useState(false)
	const [MouseOver, setMouseOver] = React.useState(false)

	React.useEffect(() => {
		setEditMode(SPServices.isInEditMode());
	}, [])





	return (
		<div className="ms-dialogHidden" onMouseOver={() => setMouseOver(true)} onMouseLeave={() => setMouseOver(false)}>
			<header className={EditMode & MouseOver ? classes.borderShadow : null}>
				{/* <!-- header container start here--> */}

				{(EditMode & MouseOver) ?
					<div className={classes['ms-Icon'] + ' ' + classes['ms-Icon--Edit']}
						onClick={() => { SPServices.OpenModalDialog('/Lists/ArtDevHeaderMenu/VewTable.aspx', 800, 800) }} >
					</div> : null
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


		</div>
	)
}

ExecuteOrDelayUntilScriptLoaded(() => {

	ReactDOM.render(
		<Header />,
		document.getElementById("header")
	)

}, "sp.js");

