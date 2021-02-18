import { IconButton, Image, Label, Panel, PanelType, Stack, Text } from 'office-ui-fabric-react'
import React from 'react'
import { EditWrapper } from '../EditWrapper'
import { FilePicker } from '../FilePicker'


export const Logo = () => {


    const [clickedLogo, setclickedLogo] = React.useState(false)	
	const [ImageSearch, setImageSearch] = React.useState(false)

    return(
        <EditWrapper onClickCallBack={() => { setclickedLogo(!clickedLogo) }} >
								<div id="logo">
									<a href="/">
										<img className="img-responsive logochange" alt="logo" title="logo" src="/_layouts/15/JobPortal/images/logo.png" />
									</a>
								</div>
								<Panel
									isOpen={clickedLogo}
									onDismiss={() => { setclickedLogo(!clickedLogo) }}
									closeButtonAriaLabel="Close"
									headerText = "Logo Edit"
								>
									<Stack>
										<Text>If You want to change image Logo click ImageSearch icon</Text>
										<br />
										<Label>Image:</Label>
										<Image src="/_layouts/15/JobPortal/images/logo.png" />
										<Stack horizontal>
											<IconButton iconProps={{ iconName: 'ImageSearch' }} onClick={() => { setImageSearch(!ImageSearch) }} />
											<IconButton iconProps={{ iconName: 'Clear' }} onClick={() => { console.log('Clicked') }} />
										</Stack>
									</Stack>
									<Panel
										isOpen={ImageSearch}
										onDismiss={() => { setImageSearch(!ImageSearch) }}
										closeButtonAriaLabel="Close"
										type={PanelType.large}
										headerText = "Search Image"
									>
                                        <FilePicker />
									</Panel>
								</Panel>
							</EditWrapper>
    )
}