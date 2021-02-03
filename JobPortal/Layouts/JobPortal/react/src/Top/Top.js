import React from 'react'
import ReactDOM from 'react-dom'

const Top = () => {


    return (
        <div id="top">
            {/*  <!-- top container start here -->   */}
            <div className="container ms-dialogHidden">
                <div id="top-links">
                    <ul className="list-inline pull-left button">
                        <li>
                            <a href="/"><span>HOME</span></a>
                        </li>
                        <li>
                            <a href="about.html"><span>ABOUT US</span></a>
                        </li>
                        <li>
                            <a href="contact.html"><span>CONTACT US</span></a>
                        </li>
                        <li>
                            <a href="contact.html"><span>EMAIL : INFO@JOBPORTAL.COM</span></a>
                        </li>
                    </ul>
                    <ul className="list-inline pull-right icon">
                        <li>
                            <a href="https://www.facebook.com/" target="_blank"><i className="fa fa-facebook" aria-hidden="true"></i></a>
                        </li>
                        <li>
                            <a href="https://twitter.com/" target="_blank"><i className="fa fa-twitter" aria-hidden="true"></i></a>
                        </li>
                        <li>
                            <a href="https://plus.google.com/" target="_blank"><i className="fa fa-google-plus" aria-hidden="true"></i></a>
                        </li>
                        <li>
                            <a href="https://www.instagram.com/" target="_blank"><i className="fa fa-instagram" aria-hidden="true"></i></a>
                        </li>
                        <li>
                            <a href="https://in.pinterest.com/" target="_blank"><i className="fa fa-pinterest-p" aria-hidden="true"></i></a>
                        </li>
                    </ul>
                </div>
            </div>
            {/* <!-- top container end here--> */}
        </div>

    )
}

ReactDOM.render(
    <Top />,
    document.getElementById('Top')
)