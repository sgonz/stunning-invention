#!/bin/sh


OUT_DIR="./"
#OUT_FILE="FiltersTest.exe"
OUT_FILE="GraphTest.exe"



FILTER_LIB="Filters/*.cs"
FILTER_LIB_TESTS="Filters/UnitTests/*.cs"

TEST_LIB="TestInterface/*.cs"

FORM_LIB="GraphInterface/*.cs"


#mcs -debug -pkg:dotnet ${FILTER_LIB} ${FILTER_LIB_TESTS} ${TEST_LIB}  -out:"${OUT_DIR}${OUT_FILE}"
mcs -debug -pkg:dotnet ${FILTER_LIB} ${FORM_LIB}  -out:"${OUT_DIR}${OUT_FILE}"
#mcs -debug -pkg:dotnet ${FORM_LIB}  -out:"${OUT_DIR}${OUT_FILE}"

