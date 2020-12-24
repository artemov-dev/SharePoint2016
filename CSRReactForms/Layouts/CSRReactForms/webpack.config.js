var path = require('path');
 
module.exports = {
    mode: 'development',
    entry: {
               
        newsCSR: './src/NewsCsr',
        MainPage: './src/MainPage',
    },
    output: {
        path: path.resolve(__dirname, './public'),     
        publicPath: 'http://localhost:3000/public/',
        filename: "[name].bundle.js"
    },
    devtool: "source-map",
    module: {
        rules: [
            {
                test: /\.(js|jsx)?$/, 
                exclude: /node_modules/,  
                loader: "babel-loader", 
                options: {                    
                    cacheDirectory: true,
                    presets: [
                        ['@babel/preset-env', { targets: "ie 11" }]
                    ]
                }
            },
            {
                'test': /\.(ts|tsx)?$/,
                'exclude': /node_modules/,
                'loaders': ['babel-loader', 'ts-loader']                
            }
        ]
    },
    devServer: {
        contentBase: '.',
        hot: true,
        port: 3000,
        host: 'localhost',
        inline: true,
        disableHostCheck: true,
        headers: { "Access-Control-Allow-Origin": "*" }
    }
}