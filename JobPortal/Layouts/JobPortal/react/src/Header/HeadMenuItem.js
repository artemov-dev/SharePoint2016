import React from 'react'


export const HeadMenuItem = (props) => {
    var dropDownMenu = props.items.filter(value => { return value.Menu2Level != null && value.Title == props.item.Title })


    
    return (

        <li className='dropdown' >
            
            <a data-toggle="dropdown" className="dropdown-toggle" href={props.item.MenuLink}>{props.item.Title}
                {props.item.Title == "Pages" &&
                    <span className="fa fa-angle-down"></span>
                }
            </a>

            {dropDownMenu.length > 0 &&
                <div className="dropdown-menu animated fadeInDown">
                    <div className="dropdown-inner">
                        <ul className="list-unstyled">
                            {
                                dropDownMenu.map(item =>
                                    <li key={item.ID}>
                                        <a href={item.MenuLink}>{item.Menu2Level}</a>
                                    </li>
                                )

                            }
                        </ul>
                    </div>
                </div>
            }
        </li>

    )
}