LucyAndLilyFlip := function(direction, location, order, root, orient1, orient2)
	local d, sign, build, newLocation;

	d := direction + orient2; # Assume direction is scrubbed for now. 

	sign := 1 - orient1;

	build := 
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

	newLocation := build(d, order, sign);
	return newLocation;
end;

#LucyAndLilyBuild := function(d, N, s)
#	local product := E(2*N)^(2*d+1);
#	if s = -1 then
#		product := -product^-1;
#	fi;
#	product := product * (E(2*N) + E(2*N)^-1);
#	return product;
#end;
