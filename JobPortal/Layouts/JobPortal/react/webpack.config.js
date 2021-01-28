var path = require('path');
var webpack = require('webpack');

module.exports = {
    mode: 'development',
    entry: {        
        header: './src/Header/header',
        headerForm: './src/Header/headerForm',
        Slider: './src/Slider/Slider'
    },
    output: {
        path: path.resolve(__dirname, './public'),
        publicPath: 'http://localhost:3000/public/',
        filename: '[name].bundle.js',
        chunkFilename: '[name].bundle.js'
    },
    devtool: "source-map",
    resolve: {
        // Add `.ts` and `.tsx` as a resolvable extension.
        extensions: [".ts", ".tsx", ".js", ".css", ".scss"]
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)?$/,
                exclude: /node_modules/,
                loader: "babel-loader"

            },
            {
                test: /\.(ts|tsx)?$/,
                exclude: /node_modules/,
                loaders: ['babel-loader', 'ts-loader']
            },
            {
                test: /\.s[ac]ss$/i,
                use: [
                  "style-loader",
                  "css-loader",
                  {
                    loader: "sass-loader",
                    options: {
                      // Prefer `dart-sass`
                      implementation: require("sass"),
                    },
                  },
                ],
            }
        ]
    },


    plugins: [
        new webpack.ProvidePlugin({
            Promise: ['es6-promise', 'Promise']
        })
    ],

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