import * as React from 'react';
import { Stack, INavStyles, INavLinkGroup, Nav, Text, IStackStyles, getTheme, List, ITheme, mergeStyleSets, IRectangle, FocusZone } from 'office-ui-fabric-react';
import './LoadTheme';
import { SPServices } from './ArtDevServices';

interface IItem {
    ID: string;
    FileRef: string;
    File_x0020_Type: string;
}


export const FilePicker = () => {


    const theme: ITheme = getTheme();
    const { palette, fonts } = theme;
    const ROWS_PER_PAGE = 3;
    const MAX_ROW_HEIGHT = 250;
    const classNames = mergeStyleSets({
        listGridExample: {
            overflow: 'hidden',
            fontSize: 0,
            position: 'relative',
        },
        listGridExampleTile: {
            textAlign: 'center',
            outline: 'none',
            position: 'relative',
            float: 'left',
            background: palette.neutralLighter,
            selectors: {
                'focus:after': {
                    content: '',
                    position: 'absolute',
                    left: 2,
                    right: 2,
                    top: 2,
                    bottom: 2,
                    boxSizing: 'border-box',
                    border: `1px solid ${palette.white}`,
                },
            },
        },
        listGridExampleSizer: {
            paddingBottom: '100%',
        },
        listGridExamplePadder: {
            position: 'absolute',
            left: 2,
            top: 2,
            right: 2,
            bottom: 2,
        },
        listGridExampleLabel: {
            background: 'rgba(0, 0, 0, 0.3)',
            color: '#FFFFFF',
            position: 'absolute',
            padding: 10,
            bottom: 0,
            left: 0,
            width: '100%',
            fontSize: fonts.small.fontSize,
            boxSizing: 'border-box',
        },
        listGridExampleImage: {
            position: 'absolute',
            top: 0,
            left: 0,
            width: '100%',
        },
    });


    const columnCount = React.useRef(0);
    const rowHeight = React.useRef(0);

    const getItemCountForPage = React.useCallback((itemIndex: number, surfaceRect: IRectangle) => {
        if (itemIndex === 0) {
            columnCount.current = Math.ceil(surfaceRect.width / MAX_ROW_HEIGHT);
            rowHeight.current = Math.floor(surfaceRect.width / columnCount.current);
        }
        return columnCount.current * ROWS_PER_PAGE;
    }, []);

    const onRenderCell = React.useCallback((item: IItem, index: number | undefined) => {
        return (
            <div
                className={classNames.listGridExampleTile}
                data-is-focusable
                style={{
                    width: 100 / columnCount.current + '%',
                }}
            >
                <div className={classNames.listGridExampleSizer}>
                    <div className={classNames.listGridExamplePadder}>
                        <img src={item.FileRef} className={classNames.listGridExampleImage} />
                        <span className={classNames.listGridExampleLabel}>{`item ${index}`}</span>
                    </div>
                </div>
            </div>
        );
    }, []);

    const getPageHeight = React.useCallback((): number => {
        return rowHeight.current * ROWS_PER_PAGE;
    }, []);


    const navStyles: Partial<INavStyles> = {
        root: {
            overflow: 'hidden'
        },
        linkText: {
            color: '#666666'
        }
    };

    const stackNavStyles: Partial<IStackStyles> = {
        root: {
            paddingTop: 20,
            borderRight: '1px solid #ff9900',
            width: 0,
            overflow: 'hidden'
        }
    };

    const navLinkGroups: INavLinkGroup[] = [
        {
            links: [
                {
                    name: 'SharePoint',
                    url: 'key1',
                    icon: 'SharepointAppIcon16',
                    key: 'key1'

                },
                {
                    name: 'Upload',
                    url: 'key2',
                    icon: 'Upload',
                    key: 'key2'

                }
            ],
        },
    ];


    const _onClickHandler = (e: React.MouseEvent<HTMLElement, MouseEvent>) => {
        e.preventDefault();
        const parent: HTMLElement = ((e.target as HTMLElement).parentNode as HTMLElement).parentNode as HTMLElement;
        const href: string | undefined = parent.getAttribute('href') == null ? parent.getElementsByTagName('a')[0].getAttribute('href')?.valueOf() : parent.getAttribute('href')?.valueOf();
        setkey(href);

    };

    const [key, setkey] = React.useState<string | undefined>('key1');
    const [items, setitems] = React.useState([]);
    React.useEffect(() => {
        ExecuteOrDelayUntilScriptLoaded(() => {
            SPServices.getJsomListItems('', 'Site Assets',
                '<View Scope=\'RecursiveAll\'>' +
                '<Query>' +
                '<Where>' +
                '<Eq>' +
                '<FieldRef Name="FileDirRef" />' +
                '<Value Type="Text">/SiteAssets/logo</Value>' +
                '</Eq>' +
                '</Where>' +
                '</Query>' +
                '</View>')
                .then(data => setitems(data));
        }, 'sp.js');
    }, []);

    console.log(getItemCountForPage);

    return (
        <Stack horizontal tokens={{ childrenGap: 20 }} >
            <Stack.Item grow shrink styles={stackNavStyles}>
                <Nav
                    styles={navStyles}
                    groups={navLinkGroups}
                    onLinkClick={_onClickHandler}
                    selectedKey={key}
                />

            </Stack.Item>
            <Stack.Item grow={5} shrink >
                <Stack tokens={{ childrenGap: 20 }}>
                    <Text variant='xLarge'>Select File</Text>
                    <FocusZone>
                        <List
                            className={classNames.listGridExample}
                            items={items}
                            getItemCountForPage={getItemCountForPage}
                            getPageHeight={getPageHeight}
                            onRenderCell={onRenderCell}
                        />
                    </FocusZone>
                </Stack>
            </Stack.Item>
        </Stack>
    );
};




/* ReactDOM.render(
    <FilePicker />,
    document.getElementById('filepicker')
)
 */
