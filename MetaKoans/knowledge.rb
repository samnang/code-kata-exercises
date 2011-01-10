module MetaKoans
  module Attributes
    def attribute(attr_name, &block)
      if attr_name.kind_of?(Hash)
        attr_name, default_value = attr_name.first
      end

      attr_name = attr_name.to_sym
      instance_variable_name = "@#{attr_name}"

      define_method(attr_name) do
        if instance_variable_defined?(instance_variable_name)
          instance_variable_get(instance_variable_name)
        else
          default_value || (instance_eval(&block) if block_given?)
        end
      end

      define_method("#{attr_name}=") do |value|
        instance_variable_set(instance_variable_name, value)
      end

      define_method("#{attr_name}?") do
        !!__send__(attr_name)
      end
    end
  end
end

class Module
  include MetaKoans::Attributes
end
