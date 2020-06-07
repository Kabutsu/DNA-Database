module.exports = {
  presets: [
    [
      '@babel/preset-env',
      {
        targets: { esmodules: true },
      },
      'react',
    ],
    '@babel/preset-react',
  ],
  plugins: [
    '@babel/plugin-transform-runtime',
    '@babel/plugin-proposal-object-rest-spread',
    ['inline-react-svg', {
      svgo: {
        plugins: [
          {
            removeTitle: true,
          },
          {
            removeAttrs: { attrs: '(data-name)' },
          },
        ],
      },
    }],
  ],
};