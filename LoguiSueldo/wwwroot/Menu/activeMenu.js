///** add active class and stay opened when selected */
//var url = window.location;

//// for sidebar menu entirely but not cover treeview
//$('ul.sidebar-menu a').filter(function () {
//    return this.href == url;
//}).parent().addClass('active');

//// for treeview
//$('ul.treeview-menu a').filter(function () {
//    return this.href == url;
//}).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');


//// for sidebar menu entirely but not cover treeview
//$('li.sidebar-menu a').filter(function () {
//    return this.href == url;
//}).parent().addClass('active');

//// for treeview
//$('li.treeview-menu a').filter(function () {
//    return this.href == url;
//}).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');




/** add active class and stay opened when selected */
var url = window.location;

// for sidebar menu entirely but not cover treeview
$('ul.sidebar-menu a').filter(function () {
    return this.href == url;
}).parent().addClass('active');
//Top bar
$('ul.navbar-nav a').filter(function () {
    return this.href == url;
}).parent().addClass('active');

// for treeview
$('ul.treeview-menu a').filter(function () {
    return this.href == url;
}).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');