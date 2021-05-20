LucyAndLilyFlip := function(direction, piece) #location, order, root, orient1, orient2)
	local d, sign, buildShift, 
	newOrient1, newOrient2, newLocation,
	output;

	d := direction + piece.orient2; # Assume direction is scrubbed for now. 

	sign := 1 - piece.orient1;

	buildShift := 
		function(d, N, s)
			local product;
			product := E(2*N)^(2*d+1);
			if s = -1 then
				product := -product^-1;
			fi;
			product := product * (E(2*N) + E(2*N)^-1);
			return product;
		end;
	# assigned;

	newLocation := piece.location + buildShift(d, piece.order, sign);
	newOrient1 := 1 - piece.orient1;
	newOrient2 := (-2 * d - 1 + piece.orient2 + 3*piece.order) mod piece.order;
	#location, order, root, orient1, orient2
	output := rec(location:= newLocation,
		   		  order := piece.order,
		   		  orient1:= newOrient1,
				  orient2:= newOrient2);
	return output;
end;

#LucyAndLilyBuild := function(d, N, s)
#	local product := E(2*N)^(2*d+1);
#	if s = -1 then
#		product := -product^-1;
#	fi;
#	product := product * (E(2*N) + E(2*N)^-1);
#	return product;
#end;
