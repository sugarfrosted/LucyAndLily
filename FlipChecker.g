Read("./FlipImplementation.gi");

LLTestUnflip := function(assert)
	local direction, piece, result, success;
	# test flipping in and out
	direction := 1;
	piece := rec(
		location:= 0,
		order:= 5,
		orient1:=0,
		orient2:=0);
	result := LucyAndLilyFlip(1,piece);
	result := LucyAndLilyFlip(1,result);

	success := assert.AreEqual(piece,result,
			"Flipping over same edge should fix shape");
	if not success then
		return false;
	fi;
	
	return true;
end;

LLRunTestBattery := function()
	local assert;
	assert:= LLSetupTests();

	if not LLTestUnflip(assert) then
		return false;
	fi;
	return true;
end;

LLSetupTests := function()
	local assert;
	assert := rec();
	assert.AreEqual:= function (expected, actual, text)
		if expected <> actual then
			Print("Equality Failed: "); Print(text); Print("\n"); 
			Print("Expected: "); Print(expected); Print("\n");
			Print("Actual: "); Print(actual); Print("\n");
			return false;
		fi;
		return true;
	end;

	return assert;
end;





