
function ChangeMenuView(viewName, controller,id) {
    $(".nav-treeview a").removeClass('active');
    $(".has-treeview a").removeClass('active');
    $(id).addClass('active');
    $(id).parent().parent().parent().children('a').addClass('active');
    var urlpath = '/'+controller+'/ChangeMenuView';
    $.ajax({
        url: urlpath,
        type: "Post",
        headers: {
            'Authorization': 'Bearer ' + sessionStorage.getItem('access_token')
        },
        data: { ViewName: viewName },
        success: function (data) {
            $('#hompepagecontainer').empty();
            $('#hompepagecontainer').html(data);
        }, error: function () {
            $('#hompepagecontainer').empty();
            $('#hompepagecontainer').html("Error");
        }
    });
}


function UploadFiles(folderNo, folderinput, callback) {
    var returnFile;
    var fileData = new FormData();
    var fileUpload = $(folderinput).prop('files');
    for (var i = 0; i < fileUpload.length; i++) {
        fileData.append(fileUpload[i].name, fileUpload[i]);
    }
    fileData.append('folderNo', folderNo);
    var urlpath = "/Home/UploadLogoOrFile";
    $.ajax({
        url: urlpath,
        type: "post",
        processData: false,
        contentType: false,
        data: fileData,
        success: function (result) {
            returnFile = result;
            callback(returnFile);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function readURL(input, imagediv) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(imagediv).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]); // convert to base64 string
    }
}