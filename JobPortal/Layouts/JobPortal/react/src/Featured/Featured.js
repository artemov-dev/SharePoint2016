import React from 'react'
import ReactDOM from 'react-dom'


const Featured = () => {
    return(
        /* <!-- featured start here --> */
		<div className="container">
			<div className="row">
				{/* <!-- featured-jobs start here --> */}
				<div className="featured-jobs">
					<h1>FEATURED JOBS</h1>
					<div className="border"></div>
					<div className="border1"></div>
				</div>
				{/* <!-- featured-jobs end here --> */}
				
				
				<div className="col-md-3 col-sm-3 col-xs-12">
					<div className="product-box">
						<div className="image">
							<a href="jobs.html">
								<img className="img-responsive" src="/_layouts/15/JobPortal/images/jobs.jpg" alt="p1" title="p1"/>
							</a>	
								<div className="buttons">
									<div className="open-down">
										<button type="button" className="rotate1">
											<i className="fa fa-link" aria-hidden="true"></i>
										</button>
										<button type="button" className="rotate1">
											<i className="fa fa-search" aria-hidden="true"></i>
										</button>
									</div>
								</div>		
						</div>		
						<div className="matter">
							<h1>IT Department Manager</h1>
							<ul className="list-inline">
								<li>
									<a href="#"><i className="fa fa-bookmark" aria-hidden="true"></i> Full Time</a>
								</li>
								<li>
									<a href="#"><i className="fa fa-map-marker" aria-hidden="true"></i> Chandigarh</a>
								</li>
							</ul>
							<p>There are many variations of passages of lorem Ipsum available [...]</p>
						</div>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("jobs.aspx", "_self") }}>VIEW MORE</button>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("apply-job-form.aspx", "_self") }}>APPLY NOW</button>
					</div>
				</div>
				
				<div className="col-md-3 col-sm-3 col-xs-12">
					<div className="product-box">
						<div className="image">
							<a href="jobs.html">
								<img className="img-responsive" src="/_layouts/15/JobPortal/images/jobs.jpg" alt="p2" title="p2"/>
							</a>	
								<div className="buttons">
									<div className="open-down">
										<button type="button" className="rotate1">
											<i className="fa fa-link" aria-hidden="true"></i>
										</button>
										<button type="button" className="rotate1">
											<i className="fa fa-search" aria-hidden="true"></i>
										</button>
									</div>
								</div>		
						</div>		
						<div className="matter">
							<h1>IT Department Manager</h1>
							<ul className="list-inline">
								<li>
									<a href="#"><i className="fa fa-bookmark" aria-hidden="true"></i> Full Time</a>
								</li>
								<li>
									<a href="#"><i className="fa fa-map-marker" aria-hidden="true"></i> Chandigarh</a>
								</li>
							</ul>
							<p>There are many variations of passages of lorem Ipsum available [...]</p>
						</div>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("jobs.aspx", "_self") }}>VIEW MORE</button>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("apply-job-form.aspx", "_self") }}>APPLY NOW</button>
					</div>
				</div>
				
				<div className="col-md-3 col-sm-3 col-xs-12">
					<div className="product-box">
						<div className="image">
							<a href="jobs.html">
								<img className="img-responsive" src="/_layouts/15/JobPortal/images/jobs.jpg" alt="p3" title="p3"/>
							</a>	
								<div className="buttons">
									<div className="open-down">
										<button type="button" className="rotate1">
											<i className="fa fa-link" aria-hidden="true"></i>
										</button>
										<button type="button" className="rotate1">
											<i className="fa fa-search" aria-hidden="true"></i>
										</button>
									</div>
								</div>		
						</div>		
						<div className="matter">
							<h1>IT Department Manager</h1>
							<ul className="list-inline">
								<li>
									<a href="#"><i className="fa fa-bookmark" aria-hidden="true"></i> Full Time</a>
								</li>
								<li>
									<a href="#"><i className="fa fa-map-marker" aria-hidden="true"></i> Chandigarh</a>
								</li>
							</ul>
							<p>There are many variations of passages of lorem Ipsum available [...]</p>
						</div>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("jobs.aspx", "_self") }}>VIEW MORE</button>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("apply-job-form.aspx", "_self") }}>APPLY NOW</button>
					</div>
				</div>
				
				<div className="col-md-3 col-sm-3 col-xs-12">
					<div className="product-box">
						<div className="image">
							<a href="jobs.html">
								<img className="img-responsive" src="/_layouts/15/JobPortal/images/jobs.jpg" alt="p4" title="p4"/>
							</a>	
								<div className="buttons">
									<div className="open-down">
										<button type="button" className="rotate1">
											<i className="fa fa-link" aria-hidden="true"></i>
										</button>
										<button type="button" className="rotate1">
											<i className="fa fa-search" aria-hidden="true"></i>
										</button>
									</div>
								</div>		
						</div>		
						<div className="matter">
							<h1>IT Department Manager</h1>
							<ul className="list-inline">
								<li>
									<a href="#"><i className="fa fa-bookmark" aria-hidden="true"></i> Full Time</a>
								</li>
								<li>
									<a href="#"><i className="fa fa-map-marker" aria-hidden="true"></i> Chandigarh</a>
								</li>
							</ul>
							<p>There are many variations of passages of lorem Ipsum available [...]</p>
						</div>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("jobs.aspx", "_self") }}>VIEW MORE</button>
						<button type="button" className="btn btn-info" onClick={()=>{window.open("apply-job-form.aspx", "_self") }}>APPLY NOW</button>
					</div>
				</div>
			</div>
		</div>
	
/* <!-- featured end here --> */

    )
}


ReactDOM.render(
    <Featured />,
    document.getElementById('featured')
)