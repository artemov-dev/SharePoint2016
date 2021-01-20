import React from 'react'
import { SPServices } from '../ArtDevServices'


export const HeadMenuItem = (props) => {
    var dropDownMenu = props.items.filter(value => { return value.Menu2Level != null && value.Title == props.item.Title })

    const [EditMode, setEditMode] = React.useState(false)
    const [MouseOver, setMouseOver] = React.useState(false)

	React.useEffect(() => {                        
        SPServices.isInEditMode().then(data => setEditMode(data))        
    }, [])  
   
 
    const BorderShadow = {
    minHeight: '100px !important',
    borderWidth: '1px',
    borderStyle: 'solid',
    borderColor: 'rgb(198, 198, 198)',
    borderImage: 'initial',
    padding: '0px'
    }

    const IconStyle = {
        float:'right', 
        marginTop:'-15px', 
        marginRight:'-15px'
    }

    const IconBorderShadowStyle = Object.assign(IconStyle, BorderShadow)

    
    return (

        <li className="dropdown" style={EditMode && MouseOver ? BorderShadow: null}  onMouseLeave={()=> setMouseOver(false)} onMouseOver={() => setMouseOver(true)} >
            {EditMode && MouseOver &&	

                <i className="ms-Icon ms-Icon--Edit"                
                style={IconBorderShadowStyle}
                onClick={() => {SPServices.OpenModalDialog('/Lists/ArtDevHeaderMenu/EditForm.aspx?ID='+ props.item.ID )}} 
                onMouseLeave={()=> setMouseOver(false)} 
                onMouseOver={() => setMouseOver(true)}
                ></i>
			}
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