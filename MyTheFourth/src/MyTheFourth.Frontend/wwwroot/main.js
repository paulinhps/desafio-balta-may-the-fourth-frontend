window.toggleTheme = function () {
  document.body.dataset.bsTheme = getBsTheme() === 'light' ? 'dark' : 'light';
};

window.setTheme = function (_theme) {
  if (_theme) document.body.dataset.bsTheme = _theme;
};

window.getBsTheme = function () {
  return document.body.dataset.bsTheme;
};
