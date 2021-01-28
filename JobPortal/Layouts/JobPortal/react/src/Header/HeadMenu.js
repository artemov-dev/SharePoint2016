import React from 'react'
import {SPServices} from '../ArtDevServices'
import { HeadMenuItem } from './HeadMenuItem'




export const HeadMenu = () => {

    const [items, setitems] = React.useState([])
    
      React.useEffect(() => {                      
        SPServices.getJsomListItems("", "ArtDev меню", "<View Scope='RecursiveAll'><Query><OrderBy><FieldRef Name='MenuOrderNumber' Ascending='TRUE' /></OrderBy></Query></View>")
         .then(data => setitems(data))               
    }, [])   

  
    return (
        <div className="col-sm-6 col-md-6 col-xs-12 padd0">
					{/* <!-- menu start here--> */}                                        
					<nav className="navbar" id="menu" >
						<div className="navbar-header">
							<span className="menutext visible-xs">Menu</span>
							<button data-target=".navbar-ex1-collapse" data-toggle="collapse" className="btn btn-navbar navbar-toggle" type="button"><i className="fa fa-bars" aria-hidden="true"></i></button>
						</div>
						<div className="collapse navbar-collapse navbar-ex1-collapse padd0">
							<ul className="nav navbar-nav pull-left">
                            {                               
                                items.filter(value => {return value.Menu2Level == null}).map(item =>                                     
                                <HeadMenuItem key={item.ID} item={item} items={items} /> 
                                )
                            }
                            </ul>
						</div>

					</nav>
					{/* <!-- menu end here --> */}
		</div>

    )
}
