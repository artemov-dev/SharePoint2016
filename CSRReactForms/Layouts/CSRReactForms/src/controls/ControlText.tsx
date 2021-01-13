import * as React from 'react';
import { TextField } from 'office-ui-fabric-react/lib/TextField';

export const ControlText: React.FC<any> = (props) => {      
      const [value, setValue] = React.useState(props.value);
      return (      
          <TextField 
            id={props.id}
            errorMessage={props.error}
            autoComplete = "off"
            value={value}
            onChange={e => {setValue((e.target as HTMLInputElement).value)}}
          />
      );
  };

 