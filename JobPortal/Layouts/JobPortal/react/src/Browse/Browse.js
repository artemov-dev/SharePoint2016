import React from 'react'
import ReactDOM from 'react-dom'

const Browse = () => {
    return (
        /* <!-- browse start here --> */
        <div className="browse">
            <div className="container">
                <div className="row">
                    {/* <!-- featured-jobs start here --> */}
                    <div className="browse-jobs">
                        <h1>BROWSE JOBS</h1>
                        <div className="border"></div>
                        <div className="border1"></div>
                    </div>
                    {/* <!-- featured-jobs end here --> */}


                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-desktop" aria-hidden="true"></i>
                                    <span>Information Technology</span>
                                </div>
                            </a>
                        </div>
                    </div>

                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-university" aria-hidden="true"></i>
                                    <span>Banking</span>
                                </div>
                            </a>
                        </div>
                    </div>

                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-money" aria-hidden="true"></i>
                                    <span>Accounting</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-bar-chart" aria-hidden="true"></i>
                                    <span>Sales & marketing</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-tachometer" aria-hidden="true"></i>
                                    <span>Digital & Creative</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-suitcase" aria-hidden="true"></i>
                                    <span>Management</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-gavel" aria-hidden="true"></i>
                                    <span>Legal Jobs</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="col-md-3 col-sm-3 col-xs-12">
                        <div className="matter">
                            <a href="jobs.html">
                                <div className="boxbor">
                                    <i className="fa fa-tags" aria-hidden="true"></i>
                                    <span>Retail</span>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        /* <!-- browse end here --> */
    )
}


ReactDOM.render(
    <Browse />,
    document.getElementById('browse')
)