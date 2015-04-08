var homeViewModel;

function cost(employeeId, employeeName, numberOfDependents, costOfBenefits) {
    var self = this;

    self.id = ko.observable(employeeId);
    self.name = ko.observable(employeeName);
    self.numberOfDependents = ko.observable(numberOfDependents);
    self.cost = ko.observable(costOfBenefits);

}

function employee (employeeName, numberOfDependents) {
    var self = this;

    self.name = ko.observable(employeeName);
    self.numberOfDependents = ko.observable(numberOfDependents);

    self.addEmployee = function () {
        var data = ko.toJSON(this);

        $.ajax({
            url: "/employees",
            type: "post",
            data: data,
            contentType: "application/json",
            success: function (employee) {

                $.getJSON("/employees/" + employee.Id + "/benefits", function (d) {
                    homeViewModel.benefitCosts.costs.push(new cost(d.EmployeeId, d.EmployeeName, d.NumberOfDependents, d.CostOfBenefits));
                });

                self.name("");
                self.numberOfDependents("");
            }
        });
    };
}

function costList() {
    var self = this;

    self.costs = ko.observableArray([]);

    self.getCosts = function () {
        self.costs.removeAll();

        $.getJSON("/benefits", function (data) {
            $.each(data, function (key, value) {
                self.costs.push(new cost(value.EmployeeId, value.EmployeeName,
                    value.NumberOfDependents, value.CostOfBenefits));
            });
        });
    }

    self.removeCost = function (cost) {
        $.ajax({
            url: "/employees/" + cost.id(),
            type: "delete",
            contentType: "application/json",
            success: function () {
                self.costs.remove(cost);
            }
        });
    }
}

homeViewModel = {
    employee : new employee(),
    cost: new cost(),
    benefitCosts: new costList()
}

$(Document).ready(function () {
    ko.applyBindings(homeViewModel);

    homeViewModel.benefitCosts.getCosts();
});