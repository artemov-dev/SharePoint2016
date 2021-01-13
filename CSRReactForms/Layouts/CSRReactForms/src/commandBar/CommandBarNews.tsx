import * as React from 'react';
import { CommandBar, ICommandBarItemProps } from 'office-ui-fabric-react/lib/CommandBar';
import { IButtonProps, IButtonStyles } from 'office-ui-fabric-react/lib/Button';
import { IContextualMenuItemStyles, IContextualMenuStyles } from 'office-ui-fabric-react';

interface props {
  LinkNewForm: string
}

export const CommandBarNews: React.FunctionComponent<props> = (props) => {

  const _items: ICommandBarItemProps[] = [
    {
      key: 'AddNews',
      text: 'AddNews',
      iconProps: { iconName: 'Add' },
      split: true,
      ariaLabel: 'AddNews',            
      href: props.LinkNewForm
    }
  ];

  
  

  return (
    <div>
      <CommandBar
        items={_items}
      />
    </div>
  );
};


