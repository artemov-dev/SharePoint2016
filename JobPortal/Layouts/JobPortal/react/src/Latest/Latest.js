import React from 'react'
import ReactDOM from 'react-dom'

const Latest = () => {
    return (
        /* <!-- latest start here --> */	
		<div className="container">
			<div className="row">
				{/* <!-- latest-candidate start here --> */}
				<div className="latest-candidate">
					<h1>OUR LATEST CANDIDATES</h1>
					<div className="border"></div>
					<div className="border1"></div>
				</div>
				{/* <!-- latest-candidate end here --> */}
				
				
				<div id="latests" className="owl-carousel">
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-1" title="cand-1" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-2" title="cand-2" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-3" title="cand-3" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-4" title="cand-4" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-5" title="cand-5" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-6" title="cand-6" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-1" title="cand-1" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-2" title="cand-2" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-3" title="cand-3" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
					<div className="item">
						<div className="col-sm-12 col-md-12 col-lg-12 col-xs-12">
							<div className="candidate">
								<img src="/_layouts/15/JobPortal/images/pic.jpg" className="img-responsive" alt="cand-4" title="cand-4" />
								<h1>John Doe</h1>
								<p>Web Designer </p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>	
/* <!-- latest end here --> */
    )
}


ReactDOM.render(
    <Latest />,
    document.getElementById('latest')
)