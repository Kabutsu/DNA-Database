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
                '#{OptimizelySDKKey}': 'KaDAZbXUQ3f7NDsfCX5zsS',
                '#{AuthenticationWebsiteUrl}': 'http://localhost:2662',
                '#{MessagingWebSocketUrl}': 'ws://localhost:5000',
                '#{MarketWebsiteUrl}': 'http://localhost:55435',
                '#{MarketScopes}': 'openid profile Zupa.Organisations Zupa.Contacts Zupa.Recipes Zupa.Products Zupa.Media Zupa.Orders Zupa.Stock Zupa.Safe Zupa.Messaging Zupa.Groups Zupa.Occasions Zupa.Authentication Zupa.Agreements Zupa.ProductCategories Zupa.Notifications.NotificationsService Zupa.Finance.Record',
                '#{OrganisationServiceUrl}': 'http://localhost:38800',
                '#{FinanceRecordServiceUrl}': 'http://localhost:38810',
                '#{ContactsWebsiteUrl}': 'http://localhost:21495',
                '#{RecipesWebsiteUrl}': 'http://localhost:5001',
                '#{ProductsWebsiteUrl}': 'http://localhost:27249',
                '#{ProductStoreWebsiteUrl}': 'https://localhost:5301',
                '#{ProductCatalogWebsiteUrl}': 'https://localhost:5201',
                '#{ProductCategoriesWebsiteUrl}': 'http://localhost:2413',
                '#{AgreementsWebsiteUrl}': 'http://localhost:44302',
                '#{AgreementsWriteWebsiteUrl}': 'https://localhost:6201',
                '#{AgreementsReadWebsiteUrl}': 'https://localhost:58920',
                '#{MediaWebsiteUrl}': 'http://localhost:6896',
                '#{OrdersServiceUrl}': 'http://localhost:5555',
                '#{StockWebsiteUrl}': 'http://localhost:50827',
                '#{SafeWebsiteURL}': 'http://localhost:4937',
                '#{NotificationsServiceWebsiteURL}': 'http://localhost:54772',
                '#{MessagingUrl}': 'ws://localhost:5000',
                '#{ContactsApiUrl}': 'http://localhost:21495/api/v1/contacts/',
                '#{PostcodeLookupUrl}': 'https://api.craftyclicks.co.uk',
                '#{PostcodeLookupApiKey}': '3ea5a-046a7-7bb2b-0350d',
            },
        }),
    ],
    mode: 'development',
    devtool: '#eval-source-map'
}