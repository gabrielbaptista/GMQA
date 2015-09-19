var Window = function(id, params) {
	this._id = id;
	this._params = params;
	this._obj = $("#" + id);
	this.init();
};

Window.prototype = {
	init : function() {
		var params = this._params;
		var content = this._obj.children();
		this._obj.empty();
		this._bg = $("<div class=\"bg\"></div>")
			.appendTo(this._obj);
		this._bd = $("<div class=\"bd\"></div>")
			.appendTo(this._obj);
		this._fg = $("<div class=\"fg\"></div>")
			.appendTo(this._obj);
		
		// title bar
		var titleBar = $("<div class=\"titleBar\" style=\"position:absolute;\"></div>").appendTo(this._fg);
		if (params.icon) {
			$("<img class=\"icon\" style=\"position:absolute;width:16px;height:16px;\" src=\"images/dock/" + params.icon + "\" />").appendTo(titleBar);
		}
		$("<div class=\"title\" style=\"position:absolute;\">" + params.title + "</div>").appendTo(titleBar);
		if (params.hasMinBtn) {
			$("<img class=\"minBtn\" src=\"images/" + params.minBtn_0 + "\" />").css({
				"position" : "absolute",
				"width" : params.minBtnW + "px",
				"height" : params.minBtnH + "px"
			}).appendTo(titleBar);
		}
		if (params.hasMaxBtn) {
			$("<img class=\"maxBtn\" src=\"images/" + params.maxBtn_0 + "\" />").css({
				"position" : "absolute",
				"width" : params.maxBtnW + "px",
				"height" : params.maxBtnH + "px"
			}).appendTo(titleBar);
		}
		if (params.hasCloseBtn) {
			$("<img class=\"closeBtn\" src=\"images/" + params.closeBtn_0 + "\" />").css({
				"position" : "absolute",
				"width" : params.closeBtnW + "px",
				"height" : params.closeBtnH + "px"
			}).appendTo(titleBar);
		}

		// client area
		$("<div class=\"client\" style=\"position:absolute;\"></div>").append(content).appendTo(this._fg);		
			
		this.setupBehavior(this._obj);
		initReferences(this);
		var me = this;
		setTimeout(function() {
			updateElementAndReferences(me);
		}, 0);
	},
	updateUI : function(obj) {
		var params = this._params;
		var _bg = obj.children(".bg");
		var _bd = obj.children(".bd");
		var _fg = obj.children(".fg");
		var width = obj.width();
		var height = obj.height();
		
		var titleHeight = params.titleHeight;
		var clientTop = params.clientTop;
		var clientLeft = params.clientLeft;
		var clientBottom = params.clientBottom;
		var clientRight = params.clientRight;
		var startY = clientTop - titleHeight;
		
		// background filling
		var bgBdCss = {
			"top" : startY + "px",
			"height" : (height - startY) + "px",
			"border-width" : "0px"
		};
		_bg.css(bgBdCss);
		_bd.css(bgBdCss);
		generateBackgroundAndBorders(0, "", _bg, _bd, params);
		
		// title bar
		var titleBar = _fg.children(".titleBar").css({
			"top" : startY + "px",
			"width" : width + "px",
			"height" : titleHeight + "px",
			"border-width" : "0px"
		});
		generateBackgroundAndBorders(0, "header", titleBar, titleBar, params);
		titleBar.children(".linearBg").css("position", "absolute");
		
		// icon
		if (params.icon) {
			titleBar.children(".icon").css({
				"top" : startY + (titleHeight - 16) / 2 + "px",
				"left" : "6px"
			});
		}
		
		// buttons
		var btnHorAlign = params.btnHorAlign;
		var btnVertAlign = params.btnVertAlign;
		var btnSpacing = params.btnSpacing;
		var btnMargin = params.btnMargin;
		var minBtnW = params.minBtnW;
		var minBtnH = params.minBtnH;
		var maxBtnW = params.maxBtnW;
		var maxBtnH = params.maxBtnH;
		var closeBtnW = params.closeBtnW;
		var closeBtnH = params.closeBtnH;
		var buttonsHeight = Math.max(minBtnH, Math.max(closeBtnH, maxBtnH));
		var buttonCount = 0;
		var buttonsWidth = 0;
		if (params.hasMinBtn) {
			if (buttonCount > 0) {
				buttonsWidth += btnSpacing;
			}
			buttonsWidth += minBtnW;
			buttonCount ++;
		}
		if (params.hasMaxBtn) {
			if (buttonCount > 0) {
				buttonsWidth += btnSpacing;
			}
			buttonsWidth += maxBtnW;
			buttonCount ++;
		}
		if (params.hasCloseBtn) {
			if (buttonCount > 0) {
				buttonsWidth += btnSpacing;
			}
			buttonsWidth += closeBtnW;
			buttonCount ++;
		}
		var buttonY = 0;
		if (btnVertAlign == 0) {
			buttonY = (titleHeight - buttonsHeight) / 2;
		} else if (btnVertAlign == 1) {
			buttonY = titleHeight - buttonsHeight;
		}
		var buttonX = btnMargin;
		if (btnHorAlign == 0) {
			buttonX = (width - buttonsWidth) / 2;
		} else if (btnHorAlign == 1) {
			buttonX = width - buttonsWidth - btnMargin;
		}
		var buttonCss = {
			"-moz-border-radius-topleft" : "0px", 
			"-webkit-border-top-left-radius" : "0px",
			"border-top-left-radius" : "0px",
			"-moz-border-radius-topright" : "0px",
			"-webkit-border-top-right-radius" : "0px",
			"border-top-right-radius" : "0px",
			"-moz-border-radius-bottomleft" : "0px",
			"-webkit-border-bottom-left-radius" : "0px",
			"border-bottom-left-radius" : "0px",
			"-moz-border-radius-bottomright" : "0px",
			"-webkit-border-bottom-right-radius" : "0px",
			"border-bottom-right-radius" : "0px"
		};
		var btns = params.btnOrder.split(",");
		for (var i = 0; i < btns.length; i ++) {
			var btn = btns[i];
			if ($.trim(btn.toLowerCase()) == "min") {
				var minBtn = titleBar.children(".minBtn");
				if (minBtn.size() > 0) {
					minBtn.css({
						"left" : buttonX + "px",
						"top" : buttonY + "px"
					}).css(buttonCss);
					buttonX += minBtnW + btnSpacing;
				}
			} else if ($.trim(btn.toLowerCase()) == "max") {
				var maxBtn = titleBar.children(".maxBtn");
				if (maxBtn.size() > 0) {
					maxBtn.css({
						"left" : buttonX + "px",
						"top" : buttonY + "px"
					}).css(buttonCss);
					buttonX += maxBtnW + btnSpacing;
				}
			} else if ($.trim(btn.toLowerCase()) == "close") {
				var closeBtn = titleBar.children(".closeBtn");
				if (closeBtn.size() > 0) {
					closeBtn.css({
						"left" : buttonX + "px",
						"top" : buttonY + "px"
					}).css(buttonCss);
					buttonX += closeBtnW + btnSpacing;
				}
			}
		}
		
		// title text
		var iconOffset = params.icon ? 16 : 0;
		var title = titleBar.children(".title").html(params.title);
		var titleSize = getTextSize(params.title, params.f_n_0, params.f_s_0, params.f_b_0);
		var txtAlign = params.txtAlign;
		var txtMargin = params.txtMargin;
		var titleX = 0;
		if (txtAlign == -1) {
			titleX = iconOffset + txtMargin + (btnHorAlign == -1 ? buttonsWidth : 0);
		} else if (txtAlign == 1) {
			titleX = width - titleSize.width - txtMargin - (btnHorAlign == 1 ? buttonsWidth : 0);
		} else {
			titleX = (width - titleSize.width) / 2;
		}
		title.css({
			"left" : titleX + "px",
			"top" : (titleHeight - titleSize.height) / 2 + "px"
		});
		applyFontParameters(0, "", title, params);
		
		// client area
		var clientArea = _fg.children(".client").css({
			"left" : clientLeft + "px",
			"top" : clientTop + "px",
			"width" : (width - clientLeft - clientRight) + "px",
			"height" : (height - clientTop - clientBottom) + "px",
			"border-width" : "0px"
		});
		generateBackgroundAndBorders(0, "client", clientArea, clientArea, params);
		
		// shadow
		applyShadow(obj, _bd, params.shadow);
	},
	setupBehavior : function(obj) {
		var me = this;
		var params = this._params;
		var _fg = obj.children(".fg");
		var titleBar = _fg.children(".titleBar");
		titleBar.children(".title").css("cursor", "default");
		titleBar.children(".closeBtn").css("cursor", "pointer").click(function() {
			changeVisibility([obj.attr("id")], 0, true);
		});
		if (params.draggable) {
			$(document).ready(function() {
				var ownerGroup = obj.closest(".elem[id^='Group_']");
				if (ownerGroup.size() == 0) {
					var targets = [obj.attr("id")];
					var bounds = [];
					var rc = getBoundsByIds(targets, bounds);
					appendInnerObjects(rc, targets);
					var group = [];
					for (var i = 0; i < targets.length; i ++) {
						group.push($("#" + targets[i]));
					}
					obj.multiDraggable({
						"handle" : titleBar,
						"group" : group
					}).mousedown(function(e) {
						e.stopPropagation();
					});
				} else {
					var topGroup;
					while (ownerGroup.size() > 0) {
						topGroup = ownerGroup;
						ownerGroup = ownerGroup.parent().closest(".elem[id^='Group_']");
					}
					topGroup.draggable({
						"handle" : titleBar
					});
				}
			});
		}
	},
	setCurrentValue : function(value) {
		var params = this._params;
		if (params.title != value) {
			params.title = value;
			updateElementAndReferences(this);
		}
	}
};