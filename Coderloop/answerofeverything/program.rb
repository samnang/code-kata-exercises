#!/usr/bin/env ruby

EXIT_NUMBER = 42

input_file = ARGV[0]
exit unless not input_file.nil? and File.exist? input_file

File.open(input_file) do |file|
  file.each_line do |line|
    break if line.to_i == EXIT_NUMBER

    puts line
  end
end 

