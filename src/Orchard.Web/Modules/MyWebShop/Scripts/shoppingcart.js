﻿$(document).ready(function () {
    $(".shoppingcart a.icon.delete").click(function (e) {
        var $button = $(this);
        var $tr = $button.parents("tr:first");
        var $isRemoved = $("input[name$='IsRemoved']", $tr).val("true");
        var $form = $button.parents("form");

        $form.submit();
        e.preventDefault();
    });
    $(".shoppingcartAdd").click(function (e) {
        var $button = $(this);
        var $form = $button.parents("form");

        $form.submit();
        e.preventDefault();
        return false;
    });
});