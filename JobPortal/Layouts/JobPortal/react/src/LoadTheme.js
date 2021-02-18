import { getTheme, initializeIcons, loadTheme } from 'office-ui-fabric-react';


loadTheme({
	palette: {
		themePrimary: '#ff9900',
		themeLighterAlt: '#fffbf5',
		themeLighter: '#ffefd6',
		themeLight: '#ffe0b3',
		themeTertiary: '#ffc266',
		themeSecondary: '#ffa51f',
		themeDarkAlt: '#e68a00',
		themeDark: '#c27400',
		themeDarker: '#8f5600',
		neutralLighterAlt: '#f1f1f1',
		neutralLighter: '#ededed',
		neutralLight: '#e3e3e3',
		neutralQuaternaryAlt: '#d3d3d3',
		neutralQuaternary: '#cacaca',
		neutralTertiaryAlt: '#c2c2c2',
		neutralTertiary: '#a19f9d',
		neutralSecondary: '#605e5c',
		neutralPrimaryAlt: '#3b3a39',
		neutralPrimary: '#323130',
		neutralDark: '#201f1e',
		black: '#000000',
		white: '#f7f7f7',
	},
});

initializeIcons('/_layouts/15/JobPortal/react/public/fluenticons/', { disableWarnings: true });



