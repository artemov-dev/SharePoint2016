import React from 'react'
import ReactDOM from 'react-dom'
import WindowSizeHook from '../owlCarousel/WindowSizeHook'



const TestImomial = () => {
    return (
        /* <!-- testimonial start here --> */
        <div style={{width: WindowSizeHook().width }}>
            <div className="container">
                <div className="row">
                    {/* <!-- testimonial-jobs start here --> */}
                    <div className="testimonial-jobs">
                        <h1>TESTIMONIAL</h1>
                        <div className="border"></div>
                        <div className="border1"></div>
                    </div>
                    {/* <!-- testimonial-jobs end here --> */}

                    <div id="testimonials" className="col-md-12 col-sm-12 col-xs-12 owl-carousel">
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-1" title="pic-1" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-2" title="pic-2" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-3" title="pic-3" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-1" title="pic-1" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-2" title="pic-2" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                        <div className="item">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div className="photo">
                                    <img src="/_layouts/15/JobPortal/images/cmnt-pic.jpg" className="img-responsive" alt="pic-3" title="pic-3" />
                                    <i className="fa fa-quote-left" aria-hidden="true"></i>
                                    <p>There are many variations of passages of Lorem Ipsum available, temporary  type  words </p>
                                    <span className="fa fa-quote-right" aria-hidden="true"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        /* <!-- testimonial end here --> */
    )
}

ReactDOM.render(
    <TestImomial />,
    document.getElementById('testimonial')
)