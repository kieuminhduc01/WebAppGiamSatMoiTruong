"use strict";
var KTDatatablesDataSourceAjaxServer = function () {

	var initTable1 = function () {
		var table = $('#kt_datatable');

		// begin first table
		table.DataTable({
			responsive: true,
			searchDelay: 500,
			processing: true,
			serverSide: true,
			ajax: {
				url: "/Accounts/getAllUser",
				type: 'GET'/*,
				data: {
					// parameters for custom backend script demo
					columnsDef: [
						'userName', 'fullName',
						'dob', 'email', 'phoneNumber',
						*//*'Role',*//* 'Actions'],
				},*/
			},
			columns: [
				{ data: 'userName', name: "User name" },
				{ data: 'fullName'},
				{ data: 'dob' },
				{ data: 'email' },
				{ data: 'phoneNumber' },
				{ data: 'actions', responsive:-1 },
			],
			columnDefs: [
				{
					targets :-1,
					title: 'actions',
					orderable: false,
					render: function (data, type, full, meta) {
						return '\
							<div class="dropdown dropdown-inline">\
								<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" data-toggle="dropdown">\
	                                <i class="la la-cog"></i>\
	                            </a>\
							  	<div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">\
									<ul class="nav nav-hoverable flex-column">\
							    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-edit"></i><span class="nav-text">Edit Details</span></a></li>\
							    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-leaf"></i><span class="nav-text">Update Status</span></a></li>\
							    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-print"></i><span class="nav-text">Print</span></a></li>\
									</ul>\
							  	</div>\
							</div>\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Edit details">\
								<i class="la la-edit"></i>\
							</a>\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete">\
								<i class="la la-trash"></i>\
							</a>\
						';
					},
				},
				{
					targets: -4,
					title: 'Ngày sinh',
					orderable: false,
					render: function (data, type, full, meta) {
						return data.substr(0,10);
					},
                }
			],
		});
	};

	return {

		//main function to initiate the module
		init: function () {
			initTable1();
		},

	};

}();

jQuery(document).ready(function () {
	KTDatatablesDataSourceAjaxServer.init();
});
