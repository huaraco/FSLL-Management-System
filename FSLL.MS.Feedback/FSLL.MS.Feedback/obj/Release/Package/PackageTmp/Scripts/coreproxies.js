
(
    function ($) {
        "use strict";

        if (!$) {
            throw "jQuery is required";
        }

        $.proxies = $.proxies || {};

        function getQueryString(params, queryString) {
            queryString = queryString || "";
            for (var prop in params) {
                if (params.hasOwnProperty(prop)) {
                    var val = getArgValue(params[prop]);
                    if (val === null) continue;

                    if ("" + val === "[object Object]") {
                        queryString = getQueryString(params[prop], queryString);
                        continue;
                    }

                    if (queryString.length) {
                        queryString += "&";
                    } else {
                        queryString += "?";
                    }
                    queryString = queryString + prop + "=" + val;
                }
            }
            return queryString;
        }

        function getArgValue(val) {
            if (val === undefined || val === null) return null;
            return val;
        }

        function invoke(url, type, urlParams, body) {
            url = "http://fsll.dyndns.org/Fsll_Ms_Core/" + url;
            url += getQueryString(urlParams);


            var ajaxOptions = $.extend({}, this.defaultOptions, {
                url: url,
                type: type,
                xhrFields: {
                    withCredentials: true
                }
            });

            if (body) {
                ajaxOptions.data = body;
            }

            if (this.antiForgeryToken) {
                var token = $.isFunction(this.antiForgeryToken) ? this.antiForgeryToken() : this.antiForgeryToken;
                if (token) {
                    ajaxOptions.headers = ajaxOptions.headers || {};
                }
            }

            return $.ajax(ajaxOptions);
        };

        function defaultAntiForgeryTokenAccessor() {
            return $("input[name=__RequestVerificationToken]").val();
        };

        /* Proxies */

        $.proxies.account = {
            defaultOptions: {},
            antiForgeryToken: defaultAntiForgeryTokenAccessor,



            test: function () {
                return invoke.call(this, "api/Account/Test", "get",
                            {}
                                    );
            },



            login: function (model) {
                return invoke.call(this, "api/Account/Login", "post",
                            {}
                                    , model);
            },



            isAuthorized: function (model) {
                return invoke.call(this, "api/Account/IsAuthorized", "post",
                            {}
                                    , model);
            },



            listAllMembers: function () {
                return invoke.call(this, "api/Account/ListAllMembers", "get",
                            {}
                                    );
            },



            listMemberOfGroup: function (groupid) {
                return invoke.call(this, "api/Account/ListMemberOfGroup?groupid=" + groupid, "get",
                            {
                                groupid: groupid,
                            }
                                    );
            },



            listMemberGroups: function (memberId) {
                return invoke.call(this, "api/Account/ListMemberGroups?memberId=" + memberId, "get",
                            {
                                memberId: memberId,
                            }
                                    );
            },



            isinSameGroup: function (memberId1, memberId2) {
                return invoke.call(this, "api/Account/IsInSameGroup?memberId1=" + memberId1 + "&memberId2=" + memberId2, "get",
                            {
                                memberId1: memberId1,
                                memberId2: memberId2,
                            }
                                    );
            },
        };

    }
(jQuery));