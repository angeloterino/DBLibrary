﻿strawmanVars = new Object();
var _lastrow, _lastcolor, _lastfontcolor;
var _paths = 'BOYJJByChannel';
var _viewId = 'BoyViews';
var _control = 'GetTotalByChannelType';
var _path, _pathboys = ['/BoyMassMarket/'];
var _loader = '<tr class="removeme"><td colspan="3" rowspan="5" style="border: 0px; border-image: none; text-align: center; vertical-align: middle; min-height:100px;"><img id ="rotate" src="../images/loading_anim.gif"/></td></tr>';
var _dvloader = '<tr class="removeme"><td colspan="4" rowspan="5" style="border: 0px; border-image: none; text-align: center; vertical-align: middle; min-height:100px;"><img id="rotate" src="../images/loading_anim.gif"/></td></tr>';
var _pvloader = '<tr class="removeme"><td colspan="5" rowspan="5" style="border: 0px; border-image: none; text-align: center; vertical-align: middle; min-height:100px;"><img id ="rotate" src="../images/loading_anim.gif"/></td></tr>';
var _controls = ['GetBoyData', 'GetBoyYTD', 'GetBoyTOGO', 'GetBoyTotals', 'GetBoyINT', 'GetBoyLE', 'GetBoyPBP'];
var _viewsids = ['_BoyData', '_BoyYTD', '_BoyTOGO', '_BoyTotals', '_BoyINT', '_BoyLE', '_BoyPBP'];
var _channel = ['MASS', 'OTC', 'BEAUTY', 'TOTAL'];
strawmanVars.cancelLoad = false;
$(document).ready(function () {
    $(document).on("click", ["a[role=menuitem]", "a[role=tabitem]"], function () {
        strawmanVars.cancelLoad = true;
    });
   
    //Primera llamada a la carga ajax de las tablas
    $('.mastertable').hide();

    startLoadTables();
});
startLoadTables = function () {
    total_size = _channel.length * _controls.length;
    partial_size = 0;
    if (!$('.load-mask').is(':visible')) {
        $('.load-mask').appendTo($('div#wrapper_main').parent());
        $('.loading-bar').width('1%');
        $('.load-mask').show();
    }//Si la máscara de carga está oculta la mostramos.
    strawmanVars.cancelLoad = false;
    initializeTables();
    loadTables(0, 0, 0);
}
initializeTables = function () {
    for (channelindex = 0; channelindex < _channel.length; channelindex++) {
        for (i = 0; i < _viewsids.length; i++) {
            $('#' + _paths + _channel[channelindex]).find('#' + _viewId + _viewsids[i] + '').html('');
        }
    }
}
loadTables = function (pathindex, controlindex, channelindex) {
    channelindex || (channelindex = 0);
    $('.loading-bar').css({ 'border-color': 'rgb(0,0,220)' });
    //Comprobamos la variable que indica si son Market o Brand a cargar
    //Se asigna el array con la carpeta de las vistas a la variable auxiliar.
    var _auxpath = _pathboys;
    if (pathindex < _auxpath.length && channelindex < _channel.length) {
        //Si el indice es menor que el número de carpetas, entro.
        //Asigno a la variable de la carpeta el registro actual.
        _path = _auxpath[pathindex];
        //Agrego el gif de carga
        $('#' + _paths + _viewsids[controlindex]).append(_loader);
        $('.loading-info').text('' + _path + _controls[controlindex]);
        //Se realiza la llamada Ajax por carpeta + funcion del controlador en el arrray _controls
        if (!strawmanVars.cancelLoad) {
            $.ajax({
                url: _path + _control,
                data: { '_channel': _channel[channelindex], '_type': _controls[controlindex] },
                async: true,
                contentType: 'application/html; charset=utf-8',
                type: 'GET',
                dataType: 'html'
            })
            .done(function (result) {
                //Agregamos el resultado a la tabla por id
                $('#' + _paths + _channel[channelindex]).find('#' + _viewId + _viewsids[controlindex]).append(result);
                //Eliminamos el gif de carga
                $('.removeme').remove();
                //Seguimos con la siguiente función del controlador                
                if (channelindex < _channel.length) {
                    controlindex++;
                    if (controlindex < _controls.length) {
                        partial_size++;
                        $('.loading-bar').animate({ 'border-color': 'rgb(100,100,255)' }, 'fast', function () {
                            $('.loading-bar').animate({ width: ((partial_size * 100) / total_size) + '%' }, 'fast');
                        });
                        strawmanVars.cancelLoad = false;
                        loadTables(pathindex, controlindex, channelindex);
                    }
                    else
                        loadTables(0, 0, channelindex + 1); //siguiente canal
                }
                else {
                    loadTables(pathindex + 1, 0, 0); //Hemos finalizado el array de controladores. Seguimos con la siguiente carpeta de vista
                }
            })
            .fail(function (xhr, status) {
                $('.loading-bar').css({ 'border-color': 'rgb(220,0,0)' });
                alert(status);
            });
        }
    } else {
        //Se ha finalizado la carga. De momento no hacemos nada, aquí habría que mostrar los datos, ocultando el div de carga.
        $('.mastertable').show();
        $('.loading-bar').animate({ 'border-color': 'rgb(0,220,0)' }, 'fast');
        $('.loading-bar').animate({ width: '100%', 'border-color': 'rgb(0,220,0)' }, 'fast', function () {
            $periodCombo();
            $('.load-mask').animate({ opacity: 'hide' }, 'slow', function () { $(this).hide(); });
        });
    }
}
