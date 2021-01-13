import * as React from 'react';
import { Label } from 'office-ui-fabric-react/lib/Label';
import { Pivot, PivotItem, PivotLinkSize } from 'office-ui-fabric-react/lib/Pivot';
import CSR from '../CSR';

export interface IFields {
  Title: HTMLElement,
  Body: HTMLElement,
  Expires: HTMLElement
}


export const ControlTab: React.FunctionComponent = () => {  

React.useEffect(() => {
  const Fields: IFields = CSR.Variables.Fields as IFields
  Fields.Title.style.display = 'block' 
})

  const PivotClicked = (e: any) => {
    const Fields: IFields = CSR.Variables.Fields as IFields
    Object.entries(Fields).forEach(([key, value]) => value.style.display = 'none')
    if( e.target.innerText == "Название") Fields.Title.style.display = 'block'     
    if( e.target.innerText == "Текст") Fields.Body.style.display = 'block' 
    if( e.target.innerText == "Срок") Fields.Expires.style.display = 'block' 
  }

  return(
  <div>
    <Pivot linkSize={PivotLinkSize.normal} onClick={PivotClicked}>
      <PivotItem headerText="Название" />        
      <PivotItem headerText="Текст" />
      <PivotItem headerText="Срок" />
      <PivotItem headerText="Комментарий">
        <Label>Комментарий</Label>        
      </PivotItem>
    </Pivot>
  </div>
)};  
 