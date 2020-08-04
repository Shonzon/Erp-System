
function GetAllCountry(countryId,countryselect) {
    var urlpath = '/Home/GetAllCountry';
    $.ajax({
        url: urlpath,
        dataType: 'json',
        type: "Post",
        data: { CountryId: countryId },
        async: true,
        success: function (data) {
            $(countryselect).empty();
            $(countryselect).append("<option value='0'>--Select Country--</option>");
            for (var i = 0; i < data.length; i++) {
                $(countryselect).append($("<option data-img_src='" + data[i].CountryFlag + "'></option>").val(data[i].CountryId)
                    .html(data[i].CountryName));
            }
        }
    });
}

function custom_template(obj) {
    var data = $(obj.element).data();
    var text = $(obj.element).text();
    if (data && data['img_src']) {
        img_src = location.origin + '/CountryFlag/' + data['img_src'];
        template = $("<span><img src=\"" + img_src + "\" style=\"width:30px;height:20px;\"/>  " + text + "</span>");
        return template;
    }
}