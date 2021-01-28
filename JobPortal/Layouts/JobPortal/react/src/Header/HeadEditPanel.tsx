import * as React from 'react';
import './headerEditPanel.scss';
import { SPServices } from '../ArtDevServices';
import { Nav, INavLinkGroup, INavLink } from 'office-ui-fabric-react/lib/Nav';
import { DefaultButton, IconButton, IContextualMenuProps, IIconProps, Label, Stack, TextField, values } from 'office-ui-fabric-react';
import { AnimationClassNames } from 'office-ui-fabric-react/lib/Styling';


interface IHeadMenu {
  ID: string,
  Title: string,
  Menu2Level: string,
  MenuLink: string,
  MenuOrderNumber: string
}



export const HeadEditPanel: React.FunctionComponent = () => {
  const [NavLink, setNavLink] = React.useState<INavLink[] | []>([])
  const [items, setitems] = React.useState<IHeadMenu[] | []>([])

  React.useEffect(() => {
    SPServices.getJsomListItems("", "ArtDev меню", "<View Scope='RecursiveAll'><Query><OrderBy><FieldRef Name='MenuOrderNumber' Ascending='TRUE' /></OrderBy></Query></View>")
      .then(data => setitems(data))
  }, [])

  React.useEffect(() => {
    const LinkTop: INavLink[] = items.filter((value: IHeadMenu) => {
      return value.Menu2Level == null
    }).map(value => {
      return { name: value.Title, url: value.MenuLink, id: value.ID, edit: false, ordernum: value.MenuOrderNumber, links: [] }
    })
    LinkTop.map((TopLink: INavLink) => {
      return items.filter((value: IHeadMenu) => {
        return value.Title == TopLink.name && value.Menu2Level != null
      }).map(value => {
        TopLink.links?.push({ name: value.Menu2Level, url: value.MenuLink, id: value.ID, edit: false, ordernum: value.MenuOrderNumber, links: [] })
      })
    })
    setNavLink(LinkTop)
  }, [items])

  const _onClickHandler = (e: React.MouseEvent<HTMLElement, MouseEvent>) => {
    const tag: string = (e.target as HTMLInputElement).tagName
    if (tag == 'SPAN' || tag == 'LABEL') {
      const id: string = e.currentTarget.getElementsByTagName('label').length ?
        e.currentTarget.getElementsByTagName('label')[0].id :
        e.currentTarget.getElementsByTagName('button')[0].id

      NavLink.forEach((link1: INavLink) => {
        link1.id == id ? link1.edit = !link1.edit : null
        link1.links?.forEach((link2: INavLink) => {
          link2.id == id ? link2.edit = !link2.edit : null
        })
      })
    }
    e.preventDefault()
  }


  const _onClickSaveIcon = (e: React.MouseEvent<HTMLElement>) => {
    NavLink.forEach((link1: INavLink) => {
      link1.id == e.currentTarget.id ? link1.edit = !link1.edit : null
      link1.links?.forEach((link2: INavLink) => {
        link2.id == e.currentTarget.id ? link2.edit = !link2.edit : null
      })
    })
  }

  const _onClickRemoveIcon = (e: React.MouseEvent<HTMLElement>) => {
    const NavLinkNew = NavLink.filter((link1: INavLink) => {
      link1.links = link1.links?.filter((link2: INavLink) => {
        return link2.id != e.currentTarget.id
      })
      return link1.id != e.currentTarget.id
    })
    setNavLink(NavLinkNew)

  }

  const _onClickAddIcon = (e: React.MouseEvent<HTMLElement>) => {
    
    
    const EmptyLink: INavLink = { name: '', url: '', ordernum: 0, edit: true, links: [] }
    NavLink.forEach((link1: INavLink) => {

      let shift: boolean = false;
      link1.links?.forEach((link2: INavLink) => {
        if (e.currentTarget.id == link2.id) {
          shift = true;
          EmptyLink.ordernum = link2.ordernum
          link1.links?.push(EmptyLink)
        }
        shift ? link2.ordernum = link2.ordernum + 1: null

      })
    })


    console.log(NavLink)
  }

  const _onChangeTextField = (e: React.FormEvent<HTMLInputElement>) => {
    const element = e.target as HTMLInputElement
    NavLink.forEach((link1: INavLink) => {
      if (link1.id == element.id) { element.title == "url" ? link1.url = element.value : link1.name = element.value; }
      link1.links?.forEach((link2: INavLink) => {
        if (link2.id == element.id) { element.title == "url" ? link2.url = element.value : link2.name = element.value; }
      })
    })
  }


  let navLinkGroups: INavLinkGroup[] = [
    {
      links: NavLink
    }
  ]



  const RenderLink = (props: INavLink) => {

    const saveIcon: IIconProps = { iconName: 'Save' };
    const ChevronDownIcon: IIconProps = { iconName: 'ChevronDown' }
    const ChevronUpIcon: IIconProps = { iconName: 'ChevronUp' }


    const menuProps: IContextualMenuProps = {
      items: [
        {
          id: props.id,
          key: 'Add',
          text: 'Add',
          iconProps: { iconName: 'Add' },
          onClick: _onClickAddIcon
        },
        {
          id: props.id,
          key: 'Remove',
          text: 'Remove',
          iconProps: { iconName: 'Remove' },
          onClick: _onClickRemoveIcon
        },
      ],
    };

    return (
      <>
        <Stack horizontal className={AnimationClassNames.slideRightIn400} verticalAlign='center' >
          {!props.edit &&
            <>
              <Label id={props.id}>{props.name}</Label>
              <IconButton iconProps={ChevronUpIcon} id={props.id} onClick={() => { }} />
              <IconButton iconProps={ChevronDownIcon} id={props.id} onClick={() => { }} />
            </>
          }
          {props.edit &&
            <>
              <TextField defaultValue={props.name} disabled={props.edit ? false : true} id={props.id} title="name" onChange={_onChangeTextField} styles={{ root: { padding: 20 } }} autoComplete="off" />
              <TextField defaultValue={props.url} disabled={props.edit ? false : true} id={props.id} title="url" onChange={_onChangeTextField} autoComplete="off" />
            </>
          }
        </Stack>
        {props.edit &&
          <>
            <IconButton iconProps={saveIcon} id={props.id} onClick={_onClickSaveIcon} />
            <IconButton menuProps={menuProps} />
          </>
        }
      </>

    )
  }




  return (
    <Stack tokens={{ maxWidth: 600 }}>
      <Nav
        ariaLabel="Head Edit Panel"
        groups={navLinkGroups}
        onRenderLink={RenderLink}
        onLinkClick={_onClickHandler}
      />
      <Stack horizontal horizontalAlign="end"  >
        <DefaultButton text="Сохранить" onClick={() => { }} />
      </Stack>
    </Stack>

  )
};
