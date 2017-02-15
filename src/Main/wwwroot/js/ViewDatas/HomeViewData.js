
var HomeViewData = function (data) {
    var self = this;
    ko.mapping.fromJs(data, {}, self);

    //var newData = ko.mapping.toJS(viewModel);
};