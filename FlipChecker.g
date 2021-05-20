Read("./FlipImplementation.gi");

LLTestUnflip := function(assert)
	local direction, piece, result, success, comparables;
	
	comparables := Immutable(["location", "order", "orientation"]);
	# test flipping in and out
	direction := 1;
	piece := rec(
		location:= 0,
		order:= 5,
		orientation:=[0,0]);
	result := LucyAndLilyFlip(1,piece);
	result := LucyAndLilyFlip(1,result);

	success := assert.RecordsMatch(piece, result, comparables);
	if not success then
		Print("Flipping over same edge should fix shape\n");
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
			Print("\tExpected: "); Print(expected); Print("\n");
			Print("\tActual: "); Print(actual); Print("\n");
			return false;
		fi;
		return true;
	end;

	assert.RecordsMatch := function(expected, actual, keys)
		# if key is empty call are equal?
		local outFunc, key;

		outFunc := function(expected, actual, key)
			Print("Records not similar on key \""); Print(key); Print("\": "); Print("\n"); 
			Print("\tExpected: "); Print(expected.(key)); Print("\n");
			Print("\tActual: "); Print(actual.(key)); Print("\n");
		end;


		for key in keys do
			if not IsBound(expected.(key)) #are they keys both not bound.
				then
					outFunc(expected,actual,key);
					return not IsBound(actual.(key));
			elif not IsBound(actual.(key))
				then
					outFunc(expected,actual,key);
					return false; # we know the expected has the key, so we have disagreement.
			elif expected.(key) <> actual.(key)
				then
					outFunc(expected,actual,key);
					return false;
			fi;
		od;
		return true;
	end;

	return assert;
end;





