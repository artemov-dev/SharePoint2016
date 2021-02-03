import React from 'react'
import ReactDOM from 'react-dom'

const Partner = () => {
    return (
        /*  <!-- partner start here --> */        
            <div className="container">
                <div className="row">
                   {/*  <!-- our-partner start here --> */}
				<div className="our-partner">
                        <h1>OUR PARTNERS</h1>
                        <div className="border"></div>
                        <div className="border1"></div>
                    </div>
                   {/*  <!-- our-partner end here --> */}

				<div id="partners" className="owl-carousel">
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l1.jpg" className="img-responsive" alt="l1" title="l1" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l2.jpg" className="img-responsive" alt="l2" title="l2" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l3.jpg" className="img-responsive" alt="l3" title="l3" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l4.jpg" className="img-responsive" alt="l4" title="l4" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l5.jpg" className="img-responsive" alt="l5" title="l5" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l1.jpg" className="img-responsive" alt="l1" title="l1" />
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-sm-12 col-md-12 col-lg-12 col-xs-12 image">
                                <img src="/_layouts/15/JobPortal/images/l2.jpg" className="img-responsive" alt="l2" title="l2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>        
        /* <!-- partner end here --> */

    )
}



ReactDOM.render(
    <Partner />,
    document.getElementById('partner')
)