import React from 'react'
import ReactDOM from 'react-dom'

const Blog = () => {
    return (
        /*  <!-- blog start here --> */
        <div className="container">
            <div className="row">
                {/* <!-- latest-blog start here --> */}
                <div className="latest-blog">
                    <h1>Latest Blog</h1>
                    <div className="border"></div>
                    <div className="border1"></div>
                </div>
                {/* <!-- latest-blog end here --> */}

                <div className="col-md-6 col-sm-6 col-xs-12">
                    {/* <!-- box start here --> */}
					<div className="box">
                        <a href="blog.html">
                            <img src="/_layouts/15/JobPortal/images/blog.jpg" alt="b1" title="b1" className="img-responsive" />
                        </a>
                        <div className="matter">
                            <h1>Tonsectetur adipiscing elit. Viva mus id interdum nibh, eu</h1>
                            <p>Aestibulum nec mauris sapien. Vestibulum ultricies quam sit amet pretium rutrum. Etiam tempus lacus in sem imperdiet ...</p>
                            <a href="blog.html">Read more	<i className="fa fa-angle-double-right" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    {/* <!-- box end here --> */}
				</div>



                <div className="col-md-6 col-sm-6 col-xs-12">
                    {/* <!-- box start here --> */}
					<div className="box">
                        <a href="blog.html">
                            <img src="/_layouts/15/JobPortal/images/blog.jpg" alt="b2" title="b2" className="img-responsive" />
                        </a>
                        <div className="matter">
                            <h1>Tonsectetur adipiscing elit. Viva mus id interdum nibh, eu</h1>
                            <p>Aestibulum nec mauris sapien. Vestibulum ultricies quam sit amet pretium rutrum. Etiam tempus lacus in sem imperdiet ...</p>
                            <a href="blog.html">Read more	<i className="fa fa-angle-double-right" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    {/* <!-- box end here --> */}
				</div>



                <div className="col-md-6 col-sm-6 col-xs-12">
                    {/* <!-- box start here --> */}
					<div className="box">
                        <a href="blog.html">
                            <img src="/_layouts/15/JobPortal/images/blog.jpg" alt="b3" title="b3" className="img-responsive" />
                        </a>
                        <div className="matter">
                            <h1>Tonsectetur adipiscing elit. Viva mus id interdum nibh, eu</h1>
                            <p>Aestibulum nec mauris sapien. Vestibulum ultricies quam sit amet pretium rutrum. Etiam tempus lacus in sem imperdiet ...</p>
                            <a href="blog.html">Read more	<i className="fa fa-angle-double-right" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    {/* <!-- box end here --> */}
				</div>



                <div className="col-md-6 col-sm-6 col-xs-12">
                    {/* <!-- box start here --> */}
					<div className="box">
                        <a href="blog.html">
                            <img src="/_layouts/15/JobPortal/images/blog.jpg" alt="b4" title="b4" className="img-responsive" />
                        </a>
                        <div className="matter">
                            <h1>Tonsectetur adipiscing elit. Viva mus id interdum nibh, eu</h1>
                            <p>Aestibulum nec mauris sapien. Vestibulum ultricies quam sit amet pretium rutrum. Etiam tempus lacus in sem imperdiet ...</p>
                            <a href="blog.html">Read more	<i className="fa fa-angle-double-right" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    {/* <!-- box end here --> */}
				</div>
            </div>
        </div>

        /* <!-- blog end here --> */
    )
}


ReactDOM.render(
    <Blog />,
    document.getElementById('blog')
)