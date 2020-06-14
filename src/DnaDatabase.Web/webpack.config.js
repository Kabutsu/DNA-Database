const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ReplacePlugin = require('webpack-plugin-replace');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
    entry: ['babel-polyfill', './client-app/index.jsx'],
    target: 'web',
    resolve: {
        extensions: ['.js', '.jsx'],
        alias: {
            react: path.resolve('./node_modules/react')
        }
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot'),
        filename: 'bundle.js',
        publicPath: '/'
    },
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            presets: ['@babel/react']
                        }
                    }
                ],
            },
            {
                enforce: 'pre',
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                loader: 'eslint-loader',
            },
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                loader: 'babel-loader',
                options: {
                    cacheDirectory: true,
                },
            },
            {
                test: /\.svg$/,
                loader: 'svg-inline-loader',
            },
            {
                test: /\.json$/,
                use: ['json-loader'],
                type: 'javascript/auto',
            },
            {
                test: /\.(png|jpg|gif)$/,
                use: [
                    {
                        loader: 'resolve-url-loader',
                        options: {
                            fallback: 'file-loader',
                            name: '[name].[ext]',
                            outputPath: 'assets/',
                            publicPath: '/assets/',
                        },
                    },
                ],
            },
            {
                test: /\.s?css$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true,
                        },
                    }
                ],
            },
        ],
    },
    devtool: 'cheap-module-eval-source-map',
    plugins: [
        new HtmlWebpackPlugin({
            template: './client-app/template.html',
            filename: './index.html',
        }),
        new ReplacePlugin({
            exclude: [
                /node_modules/,
                /obj/,
                /Properties/,
                /react/,
                /redux/,
                /\.js$/,
            ],
            values: {
                '#{DnaServiceUrl}': 'https://localhost:6001',
            },
        }),
    ],
    mode: 'development',
    devtool: '#eval-source-map'
}