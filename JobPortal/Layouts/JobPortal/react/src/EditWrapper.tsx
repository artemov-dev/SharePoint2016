import * as React from 'react'
import { Stack, IconButton } from 'office-ui-fabric-react'
import { SPServices } from './ArtDevServices'


interface IEditWrapper {
    onClickCallBack?: Function
    children: React.ReactNode  
}

export const EditWrapper = (props: IEditWrapper) => {

    
    const [MouseLogo, setMouseLogo] = React.useState(false)
    const [EditMode, setEditMode] = React.useState(false)



    React.useEffect(() => {
        setEditMode(SPServices.isInEditMode());

    }, [])

    const getStackStyles = {
        root: { border: '2px solid #ff9900' }
    }   

    

    return (
        <Stack
            styles={EditMode && MouseLogo ? getStackStyles : {}}
            onMouseOver={() => { setMouseLogo(true) }}
            onMouseLeave={() => { setMouseLogo(false) }}
        >

            {EditMode && MouseLogo &&
                <Stack.Item align='end' styles={{ root: { position: 'absolute' } }}>
                    <IconButton
                        iconProps={{ iconName: 'edit' }}
                        onClick={() => {                            
                            props.onClickCallBack != undefined ? props.onClickCallBack() : null
                        }} />
                </Stack.Item>
            }

            {EditMode && MouseLogo ?
                <Stack.Item align='center'>{props.children}</Stack.Item> :
                props.children
            }
        </Stack>
    )
}