import React, { useState, useEffect } from 'react';
import {createUseStyles} from 'react-jss';
import {useSelector, useDispatch} from 'react-redux';
import {fetchMutations} from '../redux/actions';
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import CircularProgress from '@material-ui/core/CircularProgress';

const headers = [
    { id: 'chromosome', label: 'Chromosome', minWidth: 80 },
    { id: 'start', label: 'Start', minWidth: 120 },
    { id: 'end', label: 'End', minWidth: 120 },
    { id: 'reference', label: 'Reference Allele', minWidth: 120 },
    { id: 'mutant', label: 'Mutant Allele', minWidth: 120 },
    { id: 'gene', label: 'Name', minWidth: 120 },
    { id: 'variantFunction', label: 'Variant Function', minWidth: 180 },
    { id: 'aaChange', label: 'AAChange', minWidth: 250 },
    { id: 'dbsnp', label: 'dbSNP ID', minWidth: 180 }
];

const MutationsTable = () => {
    const dispatch = useDispatch();
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(25);
    const isFetching = useSelector(state => state.isFetching);
    const rows = useSelector(state => state.dna);
    useEffect(() => {
      dispatch(fetchMutations());
    }, []);

    const handlePageChange = (event, newPage) => setPage(newPage);

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    return (
      isFetching
        ? (<CircularProgress />)
        : (
          <Paper>
            <TableContainer>
              <Table stickyHeader aria-label="sticky table">
                <TableHead>
                  <TableRow>
                    {headers.map((header) => (
                      <TableCell
                        key={header.id}
                        align={header.align}
                        style={{ minWidth: header.minWidth }}
                      >
                        {header.label}
                      </TableCell>
                    ))}
                  </TableRow>
                </TableHead>
                <TableBody>
                  {rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row) => {
                    return (
                      <TableRow hover role="checkbox" tabIndex={-1} key={row.code}>
                        {headers.map((header) => {
                          const value = row[header.id];
                          return (
                            <TableCell key={header.id} align={header.align}>
                              {header.format && typeof value === 'number' ? header.format(value) : value}
                            </TableCell>
                          );
                        })}
                      </TableRow>
                    );
                  })}
                </TableBody>
              </Table>
            </TableContainer>
            <TablePagination
              rowsPerPageOptions={[10, 25, 100]}
              component="div"
              count={rows.length}
              rowsPerPage={rowsPerPage}
              page={page}
              onChangePage={handlePageChange}
              onChangeRowsPerPage={handleChangeRowsPerPage}
            />
          </Paper>
        )
      );
};

export default MutationsTable;
