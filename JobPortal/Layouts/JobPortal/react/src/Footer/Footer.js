import React from 'react'
import ReactDOM from 'react-dom'

const Footer = () => {
    return (
        <>
            {/* <!-- Footer start here --> */}
            <footer>
                <div className="container">
                    <div className="bor col-md-12 col-sm-12 col-xs-12 padd0">
                        <div className="col-sm-5 col-md-5 col-xs-12 subscribe">
                            <h5>Subscribe Our Newsletter</h5>
                            <form name="subscribe">
                                <div className="form-group">
                                    <div className="input-group">
                                        <input type="text" placeholder="Enter your Email Address" id="subscribe_email1" name="subscribe_email" value="" className="form-control" />
                                        <div className="input-group-btn">
                                            <button className="btn btn-default btn-lg" type="submit"><i className="fa fa-paper-plane-o" aria-hidden="true"></i> SUBSCRIBE</button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div className="col-sm-4 col-md-4 col-xs-12 follow">
                            <h5>Follow us on</h5>
                            <ul className="list-inline socialicon">
                                <li>
                                    <a href="https://www.facebook.com/" target="_blank">
                                        <i className="fa fa-facebook" aria-hidden="true"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="https://twitter.com/" target="_blank">
                                        <i className="fa fa-twitter" aria-hidden="true"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="https://plus.google.com/" target="_blank">
                                        <i className="fa fa-google-plus" aria-hidden="true"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="https://www.instagram.com/" target="_blank">
                                        <i className="fa fa-instagram" aria-hidden="true"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="https://in.linkedin.com/" target="_blank">
                                        <i className="fa fa-linkedin" aria-hidden="true"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div className="col-sm-3 col-md-3 col-xs-12 need">
                            <h5>Need Help ?</h5>
                            <h6><i className="fa fa-phone" aria-hidden="true"></i> CALL US : <span>1800-0000-1234</span></h6>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-sm-3 col-md-3 col-xs-12 matter">
                            <img src="/_layouts/15/JobPortal/images/foot-logo.png" className="img-responsive" alt="foot-logo" title="foot-logo" />
                            <p>Aliquam hendrit rutrum iaculis nullam ondimentum mal uada velit beum donec sit amet tristique erosam amet risus mollis malesuada quis quis nulla. Vestibulum ante ipsum primis in faucibus orci luctus et ultr amet tristique erosam.</p>

                        </div>
                        <div className="col-sm-3 col-md-3 col-xs-12 info">
                            <h5>Information</h5>
                            <ul className="list-unstyled">
                                <li>
                                    <a href="about.html"><i className="fa fa-caret-right" aria-hidden="true"></i>About Us</a>
                                </li>
                                <li>
                                    <a href="#"><i className="fa fa-caret-right" aria-hidden="true"></i>Help Desk</a>
                                </li>
                                <li>
                                    <a href="#"><i className="fa fa-caret-right" aria-hidden="true"></i>Support</a>
                                </li>
                                <li>
                                    <a href="#"><i className="fa fa-caret-right" aria-hidden="true"></i>Privacy Policy</a>
                                </li>
                                <li>
                                    <a href="#"><i className="fa fa-caret-right" aria-hidden="true"></i>Terms & Conditions</a>
                                </li>
                            </ul>
                        </div>
                        <div className="col-sm-3 col-md-3 col-xs-12 use">
                            <h5>Useful Links</h5>
                            <ul className="list-unstyled">
                                <li>
                                    <a href="index.html"><i className="fa fa-caret-right" aria-hidden="true"></i>Homepage</a>
                                </li>
                                <li>
                                    <a href="submit-job.html"><i className="fa fa-caret-right" aria-hidden="true"></i>Submit Job</a>
                                </li>
                                <li>
                                    <a href="jobs.html"><i className="fa fa-caret-right" aria-hidden="true"></i>All Candidates</a>
                                </li>
                                <li>
                                    <a href="blog.html"><i className="fa fa-caret-right" aria-hidden="true"></i>Latest Blogs</a>
                                </li>
                                <li>
                                    <a href="jobs.html"><i className="fa fa-caret-right" aria-hidden="true"></i>Jobs</a>
                                </li>
                            </ul>
                        </div>

                        <div className="col-sm-3 col-md-3 col-xs-12 padd0">
                            <h5>Get in touch</h5>
                            <form className="form-horizontal form" method="post">
                                <fieldset>
                                    <div className="form-group">
                                        <div className="col-sm-12">
                                            <input className="form-control" id="input-username" placeholder="Name" value="" name="email" required="" type="text" />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <div className="col-sm-12">
                                            <input className="form-control" id="input-email" placeholder="Email Address" value="" name="email" required="" type="text" />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <div className="input-group col-sm-12">
                                            <input type="text" placeholder="Message" id="message" name="message" value="" className="form-control big" />
                                            <div className="input-group-btn">
                                                <button className="btn btn-default btn-lg" type="submit"><i className="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                </div>
            </footer>
            <div className="powered">
                <div className="container">
                    <p>Copyright &#169; 2017. All Rights Reserved</p>
                </div>
            </div>
            {/* <!-- Footer end here --> */}
        </>
    )
}


ReactDOM.render(
    <Footer />,
    document.getElementById('footer')
)