Read("./FlipImplementation.gi");

LLTestUnflip := function()
	local direction, piece,result;
	# test flipping in and out
	direction := 1;
	piece := rec(
		location:= 0,
		order:= 5,
		orient1:=0,
		orient2:=0);
	result := LucyAndLilyFlip(1,piece);
	result := LucyAndLilyFlip(1,result);
	if result <> piece then
		Print("Flip not undone.\n");
		Print("Expected: "); Print(piece); Print("\n");
		Print("Actual: "); Print(result); Print("\n");
		return false;
	fi;
end;

RunTestBattery := function()
	if not LLTestUnflip() then
		return;
	fi;
	return;
end;
