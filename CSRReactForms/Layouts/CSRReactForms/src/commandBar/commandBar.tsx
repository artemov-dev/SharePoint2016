import * as React from 'react';
import { CommandBar, ICommandBarItemProps } from 'office-ui-fabric-react/lib/CommandBar';
import { IButtonProps } from 'office-ui-fabric-react/lib/Button';

const overflowButtonProps: IButtonProps = { ariaLabel: 'More commands' };

export const CommandBarSplitDisabledExample: React.FunctionComponent = () => {
  return (
    <div>
      <CommandBar
        items={_items}
        overflowButtonProps={overflowButtonProps}
        ariaLabel="Use left and right arrow keys to navigate between commands"
      />
    </div>
  );
};

const _items: ICommandBarItemProps[] = [
  {
    key: 'newItem',
    text: 'New',
    iconProps: { iconName: 'Add' },
    split: true,
    ariaLabel: 'New',
    subMenuProps: {
      items: [
        { key: 'emailMessage', text: 'Email message', iconProps: { iconName: 'Mail' } },
        { key: 'calendarEvent', text: 'Calendar event', iconProps: { iconName: 'Calendar' } },
      ],
    },
  }
];
