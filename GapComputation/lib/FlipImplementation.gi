# Loads the dependencies:
LoadPackage("Float");
SetFloats(MPC);

LucyAndLilyFlip := function(direction, piece) # piece = rec(location, order, root, orientation:= [a,b])
	local d, sign, buildShiftSummand,
	newOrientation, newLocation, locationFloat,
	output;

	d := direction + piece.orientation[2]; # Assume direction is scrubbed for now. 

	if piece.orientation[1] = 1 then
		sign := -1;
	else
		sign := 1;
	fi;

	buildShiftSummand := 
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

	newLocation := piece.location + buildShiftSummand(d, piece.order, sign);
	newOrientation := [];
	newOrientation[1] := 1 - piece.orientation[1];
	newOrientation[2] := (-2 * d - 1 + piece.orientation[2] + 3*piece.order) mod piece.order;

	locationFloat := Float(newLocation);
	output := rec(location:= newLocation,
		   		  order := piece.order,
		   		  orientation:= newOrientation,
				  coordinates := rec(
					  real:= RealPart(locationFloat),
					  imag:= ImaginaryPart(locationFloat)
					 ),
				  norm:= Norm(locationFloat)
			 	 );

	return output;
end;
