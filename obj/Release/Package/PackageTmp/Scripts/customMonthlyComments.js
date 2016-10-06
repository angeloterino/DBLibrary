﻿$.strawmanVars = new Object();
$(document).ready(function () {
    $(document).on("click", ["a[role=menuitem]", "a[role=tabitem]"], function () {
        $.strawmanVars.cancelLoad = true;
    });
    //Carga de datos por Channel
    var _lastrow, _lastcolor, _lastfontcolor;
    var _paths = 'MonthlyComments';
    var _path, _pathboys = ['/MonthlyComments/'];
    var _loader = '<div class="removeme" style="border: 0px; border-image: none; text-align: center; vertical-align: middle; min-height:100px; width:100%;"><img id ="rotate" src="../images/loading_anim.gif"/></div>';
    var _stdControls = ['GetData', 'GetComments'];
    var _stdViewsids = ['_Data', '_Comments'];
    var _viewsids, _controls;
    var partial_size = 0;

    $(document).ready(function () {
        //Primera llamada a la carga ajax de las tablas
        $('.mastertable').hide();
        startLoadTables();
    });
    setPeriodData = function () {
        var _month = $('#month_control').html();
        var _year = $('#year_control').html();
        var _lastYear = parseInt(_year) - 1;
        var _versus = ' Vs '; var _ytd = 'YTD';
        var month_title = _month + ' ' + _year + _versus + _month + ' ' + _lastYear;
        var ytd_title = _ytd + ' ' + _month + ' ' + _year + _versus + _ytd + ' ' + _month + ' ' + _lastYear;
        $('.period.month').html(_month);
        $('.ytd.title').html(ytd_title);
        $('.month.title').html(month_title);
    };
    startLoadTables = function () {
        _viewsids = _stdViewsids;
        _controls = _stdControls;
        total_size = _pathboys.length * _controls.length;
        partial_size = 0;
        if (!$('.load-mask').is(':visible')) {
            $('.load-mask').appendTo($('div#wrapper_main').parent());
            $('.loading-bar').width('1%');
            $('.load-mask').show();
        }
        $.strawmanVars.cancelLoad = false;
        $.strawmanVars.cacheSet = $('#cache_set').val(); //Recogemos el estado de la caché.
        initializeTables();
        setPeriodData();
        loadTables(0, 0);
    };
    initializeTables = function () {
        for (var i = 0; i < _viewsids.length; i++) {
            $('#' + _paths + _viewsids[i]).html('');
        }
    };
    function loadTables(pathindex, controlindex) {
        $('.loading-bar').css({ 'border-color': 'rgb(0,0,220)' });
        //Comprobamos la variable que indica si son Market o Brand a cargar
        //Se asigna el array con la carpeta de las vistas a la variable auxiliar.
        var _auxpath = _pathboys;
        if (pathindex < _auxpath.length) {
            //Si el indice es menor que el número de carpetas, entro.
            //Asigno a la variable de la carpeta el registro actual.
            _path = _auxpath[pathindex];
            //Agrego el gif de carga
            $('#' + _paths + _viewsids[controlindex]).append(_loader);
            $('.loading-info').text('Cargando ' + _path + _controls[controlindex]);
            //Se realiza la llamada Ajax por carpeta + funcion del controlador en el arrray _controls
            if (!$.strawmanVars.cancelLoad) {
                $.ajax({
                    url: _path + _controls[controlindex],
                    async: true,
                    contentType: 'application/html; charset=utf-8',
                    type: 'GET',
                    dataType: 'html'
                })
                .done(function (result) {
                    //Agregamos el resultado a la tabla por id
                    $('#' + _paths + _viewsids[controlindex]).append(result);
                    //Eliminamos el gif de carga
                    $('.removeme').remove();
                    //Seguimos con la siguiente función del controlador
                    controlindex++;
                    if (controlindex < _controls.length) {
                        partial_size++;
                        $('.loading-bar').animate({ 'border-color': 'rgb(100,100,255)' }, 'slow', function () {
                            $('.loading-bar').animate({ width: ((partial_size * 100) / total_size) + '%' }, 'slow');
                        });
                        loadTables(pathindex, controlindex);
                    }
                    else {
                        //Hemos finalizado el array de controladores. Seguimos con la siguiente carpeta de vista. 
                        loadTables(pathindex + 1, 0);
                    }
                })
                .fail(function (xhr, status) {
                    $('.loading-bar').css({ 'border-color': 'rgb(220,0,0)' });
                    controlindex++;
                    if (controlindex < _controls.length) loadTables(pathindex, controlindex);
                });
            }

        } else {
            //Se ha finalizado la carga. De momento no hacemos nada, aquí habría que mostrar los datos, ocultando el div de carga.
            $('.mastertable').show();
            $('.loading-bar').animate({ 'border-color': 'rgb(0,220,0)' }, 'slow');
            $('.loading-bar').animate({ width: '100%', 'border-color': 'rgb(0,220,0)' }, 'slow', function () {
                $periodCombo();
                $('.load-mask').animate({ opacity: 'hide' }, 'slow', function () { $(this).hide() });
            });
        }
    }

    $(document).on("click", "a[role=comment-edit]", function () {
        if(HideForms()){
            var _url = $(this).attr('target-url');
            var _val = $(this).attr('select-id');
            var _target = $(this).attr('target-id');
            var _parent = $(this).attr('parent-id');
            var _form = $(this).closest('table').find('.form').clone();
            //var target = $('#' + _parent).find('textarea');
            //var id_cont = $('#' + _parent).find('input[id=id]');
            //var del_bnt = $('#' + _parent).find('a[select-id=delete-button]');
            var target = _form.find('textarea');
            var id_cont = _form.find('input[id=id]');
            var del_bnt = _form.find('a[select-id=delete-button]');
            var text = $(this).closest('p').clone();
            //ShowForms(target.parent().closest('td'));        
            _form.attr('form-mode','edit').show();
            $(this).closest('p').html(_form);
            text.clone().attr('class','hidden').hide().insertBefore(_form.parent());
            text.find('a[role=comment-edit]').parent().remove();
            $(target).closest('.wrapper.form').append(_loader);
            target.val(text.text());
            id_cont.val(_val);
            del_bnt.attr('href', del_bnt.attr('url') + '/' + _val);
            /*$.getJSON(_url, { '_id': _val })
            .done(function (result) {
            target.val(result.text);
            id_cont.val(_val);
            del_bnt.attr('href', del_bnt.attr('url') + '/' + _val);
            });*/
            $(target).closest('.wrapper.form').find('input[type=submit]').removeAttr('disabled');
            $(target).closest('.wrapper.form').find('.removeme').remove();
        }
    });
    $('div.wrapper.form').hide();

    $(document).on("click", 'a[select-id=new-comment]', function () {
        var target = ' #' + $(this).attr("target-id");
        HideForms();
        ShowForms($(this).parent().closest('td'));
    });

    $(document).on("change paste", 'textarea', function () {
        var text = $(this).val();
        if (text.length > 0)
            $(this).closest('.wrapper.form').find('input[type=submit]').removeAttr('disabled');
        else
            $(this).closest('.wrapper.form').find('input[type=submit]').attr('disabled', 'disabled');
    });
});

//Función para mostrar los formularios.
//Se basa en 
var ShowForms = function (target) {
    (target).find('.wrapper.form').show();
    (target).find('.wrapper.new').hide();
}


var HideForms = function () {
    $('p.hidden').removeClass('hidden').show();
    $('.form[form-mode=edit]').closest('p').remove();
    $('div.wrapper.form').hide();
    $('a[select-id=new-comment]').parent().show();
    $('textbox').val('');
    $('.message').html('');
    if ($('#message-gryphicon')) $('#message-gryphicon').remove();
    return true;
}

var UpdateCommentSuccess = function (_message, _container, _val) {
    var target = 'div[select-id=' + _container + ']';
    var table = 'table[id=' + _container + ']';
    var _url = $(target).attr('target-url');
    $.ajax({
        url: _url,
        data: { '_channel': _val },
        async: true,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    })
    .done(function (result) {
        $(target).html(result);
        
        SetUpdateMessage(_message, table);
    })
    .fail(function (xhr, status) {
        var x = 0;
    });

}
var UpdateCommentFailure = function () {
    alert(message);
}
var ResetCommentForm = function (xhr, status) {

    var _status = status;
    if (status == 'success') {
        var _xhr = JSON.parse(xhr.responseText);
        var _channel = _xhr.channel;
        var _container = _xhr.container + _channel;
        var _message = _xhr.message;
        UpdateCommentSuccess(_message, _container, _channel);
    }
}

var SetUpdateMessage = function (_message, _target) {
    var _textarea = $(_target).first('textarea');
    var _display = $(_target).first('.message');
    var _gryphicon = $(_target).first('#message-gryphicon');
    _textarea.val('');
    if (_display!= null) {
        _display.html(_message);
        if (_gryphicon == null) {
            $('<div/>', {
                class: 'float-left success glyphicon glyphicon-ok',
                id: 'message-gryphicon'
            }).insertBefore(_display);
        } else {
            _gryphicon
            .removeClass('glyphicon-warning-sign')
            .removeClass('glyphicon-ok')
            .addClass('glyphicon-ok')
        }
    }
}
