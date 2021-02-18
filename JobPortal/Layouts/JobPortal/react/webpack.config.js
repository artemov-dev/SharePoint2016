var path = require('path');
var webpack = require('webpack');

const isProd = process.env.NODE_ENV === 'production '

const optimization = isProd ? {
    runtimeChunk: 'single',

    splitChunks: {
        chunks: 'all',

        cacheGroups: {
            vendors: {
                test: /[\\/]node_modules[\\/]/,                    
                name: 'vendors',
                enforce: true,
                chunks: 'all'
            }
        }
    }
} : {}



module.exports = {
    mode: 'development',
    entry: {        
        Top: './src/Top/Top',
        header: './src/Header/header',
        headerForm: './src/Header/headerForm',
        Slider: './src/Slider/Slider',
        Featured: './src/Featured/Featured',
        Testimonial: './src/Testimonial/Testimonial',
        Browse: './src/Browse/Browse',
        Latest: './src/Latest/Latest',
        Partner: './src/Partner/Partner',
        Blog: './src/Blog/Blog',
        Footer: './src/Footer/Footer',
        owlCarousel: './src/owlCarousel/owlCarousel',
        FilePicker: './src/FilePicker'
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
        }),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery'
          })
    ],

    optimization: optimization,
    

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