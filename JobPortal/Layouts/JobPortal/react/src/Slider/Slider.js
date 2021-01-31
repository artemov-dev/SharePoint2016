import React from 'react'
import ReactDOM from 'react-dom'
import WindowSizeHook from './WindowSizehook';







const Slider = () => { 
    
    React.useEffect(() => {
                 
         const script = document.createElement('script');
         script.src = '/_layouts/15/JobPortal/js/internal.js';          
         document.body.appendChild(script);

    }, [])
    
    
    return (
        <div style={{width: WindowSizeHook().width }} >
            {/* <!-- slider start here --> */}
            <div className="slideshow owl-carousel">           
                <div className="item">
                    <img src="/_layouts/15/JobPortal/images/slider-1.jpg" alt="slider" title="slider" className="img-responsive" />
                    <div className="slide-detail">
                        <div className="container">
                            <div className="slider-caption">
                                <div className="off"></div>
                                <h1>Find Your Job</h1>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddleft">
                                    <select className="selectpicker form-control" name="allcate">
                                        <option value="1">All Category</option>
                                        <option value="0">Category 1</option>
                                        <option value="0">Category 2</option>
                                        <option value="0">Category 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12">
                                    <select className="selectpicker form-control" name="location">
                                        <option value="1">Select Location</option>
                                        <option value="0">Location 1</option>
                                        <option value="0">Location 2</option>
                                        <option value="0">Location 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddright">
                                    <div className="input-group">
                                        <input name="s" className="form-control" value="" onChange={()=>{}} placeholder="Search" type="text" />
                                        <span>
                                            <button type="submit" className="btnsrch" onClick={()=>{}} ><i className="fa fa-search"></i></button>
                                        </span>
                                    </div>
                                </div>
                                <div className="center">
                                    <button className="btn-default">ADVANCE JOB SEARCH <i className="fa fa-plus-square-o" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="item">
                    <img src="/_layouts/15/JobPortal/images/slider-1.jpg" alt="slider" title="slider" className="img-responsive" />
                    <div className="slide-detail">
                        <div className="container">
                            <div className="slider-caption">
                                <div className="off"></div>
                                <h1>Find Your Job</h1>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddleft">
                                    <select className="selectpicker form-control" name="allcate">
                                        <option value="1">All Category</option>
                                        <option value="0">Category 1</option>
                                        <option value="0">Category 2</option>
                                        <option value="0">Category 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12">
                                    <select className="selectpicker form-control" name="location">
                                        <option value="1">Select Location</option>
                                        <option value="0">Location 1</option>
                                        <option value="0">Location 2</option>
                                        <option value="0">Location 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddright">
                                    <div className="input-group">
                                        <input name="s" className="form-control" value="" onChange={()=>{}} placeholder="Search" type="text" />
                                        <span>
                                            <button type="submit" className="btnsrch" onClick={()=>{}} ><i className="fa fa-search"></i></button>
                                        </span>
                                    </div>
                                </div>
                                <div className="center">
                                    <button className="btn-default">ADVANCE JOB SEARCH <i className="fa fa-plus-square-o" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="item">
                    <img src="/_layouts/15/JobPortal/images/slider-1.jpg" alt="slider" title="slider" className="img-responsive" />
                    <div className="slide-detail">
                        <div className="container">
                            <div className="slider-caption">
                                <div className="off"></div>
                                <h1>Find Your Job</h1>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddleft">
                                    <select className="selectpicker form-control" name="allcate">
                                        <option value="1">All Category</option>
                                        <option value="0">Category 1</option>
                                        <option value="0">Category 2</option>
                                        <option value="0">Category 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12">
                                    <select className="selectpicker form-control" name="location">
                                        <option value="1">Select Location</option>
                                        <option value="0">Location 1</option>
                                        <option value="0">Location 2</option>
                                        <option value="0">Location 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddright">
                                    <div className="input-group">
                                        <input name="s" className="form-control" value="" onChange={()=>{}} placeholder="Search" type="text" />
                                        <span>
                                            <button type="submit" className="btnsrch" onClick={()=>{}} ><i className="fa fa-search"></i></button>
                                        </span>
                                    </div> 
                                </div>
                                <div className="center">
                                    <button className="btn-default">ADVANCE JOB SEARCH <i className="fa fa-plus-square-o" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="item">
                    <img src="/_layouts/15/JobPortal/images/slider-1.jpg" alt="slider" title="slider" className="img-responsive" />
                    <div className="slide-detail">
                        <div className="container">
                            <div className="slider-caption">
                                <div className="off"></div>
                                <h1>Find Your Job</h1>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddleft">
                                    <select className="selectpicker form-control" name="allcate">
                                        <option value="1">All Category</option>
                                        <option value="0">Category 1</option>
                                        <option value="0">Category 2</option>
                                        <option value="0">Category 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12">
                                    <select className="selectpicker form-control" name="location">
                                        <option value="1">Select Location</option>
                                        <option value="0">Location 1</option>
                                        <option value="0">Location 2</option>
                                        <option value="0">Location 3</option>
                                    </select>
                                </div>
                                <div className="col-md-4 col-sm-4 col-xs-12 paddright">
                                    <div className="input-group">
                                        <input name="s" className="form-control" value="" onChange={()=>{}} placeholder="Search" type="text" />
                                        <span>
                                            <button type="submit" className="btnsrch" onClick={()=>{}}><i className="fa fa-search"></i></button>
                                        </span>
                                    </div>
                                </div>
                                <div className="center">
                                    <button className="btn-default">ADVANCE JOB SEARCH <i className="fa fa-plus-square-o" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            {/* <!-- slider end here --> */}

        </div>
    )
}


ReactDOM.render(
    <Slider />,
    document.getElementById("Slider")
)

